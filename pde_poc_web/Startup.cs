using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

// using pde_poc_web.Models.Storage;
// using pde_poc_web.Models.Storage.Mocks;
// using pde_poc_web.Models.Engine.Lib;


using pde_poc_sim.Storage;
using pde_poc_sim.Storage.Mocks;
using pde_poc_sim.Engine.Lib;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;
using pde_poc_sim.OpenFisca;

using RestSharp;
using MyRestClient = RestSharp.RestClient;

namespace pde_poc_web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Storage
            string connectionString = Configuration.GetConnectionString("DefaultDB") ?? Environment.GetEnvironmentVariable("connectionString");
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString, b => b.MigrationsAssembly("pde-poc-web")));
            
            InjectMaternityBenefits(services);
            InjectMotorVehicle(services);

            // Common
            services.AddScoped<IJoinResults, Joiner>();
            

            // Create mocks
            services.AddScoped<MockCreator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Run initial migration
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>()) {
                    context.Database.Migrate();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MotorVehicle}/{action=Form}/{id?}");
            });
        }
   

        private void InjectMaternityBenefits(IServiceCollection services) {
            services.AddScoped<IHandleSimulationRequests<MaternityBenefitSimulationCaseRequest>, 
                SimulationRequestHandler<
                    MaternityBenefitSimulationCase, 
                    MaternityBenefitSimulationCaseRequest, 
                    MaternityBenefitPerson
                >
            >();

            services.AddScoped<
                IBuildSimulations<
                    MaternityBenefitSimulationCase, 
                    MaternityBenefitSimulationCaseRequest
                >,
                MaternityBenefitSimulationBuilder>();    
            
            services.AddScoped<IHelperStore<MaternityBenefitSimulationCase>, 
                MaternityBenefitHelperStore>();

            services.AddScoped<IStorePersons<MaternityBenefitPerson>, 
                MaternityBenefitPersonStore>();

            services.AddScoped<IRunSimulations<MaternityBenefitSimulationCase, MaternityBenefitPerson>,
                SimulationRunner<MaternityBenefitSimulationCase, MaternityBenefitPerson>>();

            services.AddScoped<IRunCases<MaternityBenefitSimulationCase, MaternityBenefitPerson>, 
                MaternityBenefitCaseRunner>();

            services.AddScoped<IExecuteRules<MaternityBenefitSimulationCase, MaternityBenefitPerson>,
                MaternityBenefitRuleExecutor>();

            services.AddScoped<IGetSimulations<MaternityBenefitSimulationCase>, MaternityBenefitSimulationGetter>();

            services.AddScoped<ISimulationLib<MaternityBenefitSimulationCase>, SimulationLib<MaternityBenefitSimulationCase>>();

            services.AddScoped<IStoreSimulations<MaternityBenefitSimulationCase>, MaternityBenefitSimulationStore>();
        }

        private void InjectMotorVehicle(IServiceCollection services) {
            services.AddScoped<IHandleSimulationRequests<MotorVehicleSimulationCaseRequest>, 
                SimulationRequestHandler<
                    MotorVehicleSimulationCase, 
                    MotorVehicleSimulationCaseRequest, 
                    MotorVehiclePerson
                >
            >();

            services.AddScoped<
                IBuildSimulations<
                    MotorVehicleSimulationCase, 
                    MotorVehicleSimulationCaseRequest
                >,
                MotorVehicleSimulationBuilder>(); 

            services.AddScoped<IHelperStore<MotorVehicleSimulationCase>, 
                MotorVehicleHelperStore>();

            services.AddScoped<IStorePersons<MotorVehiclePerson>, 
                MotorVehiclePersonStore>();

            services.AddScoped<IRunSimulations<MotorVehicleSimulationCase, MotorVehiclePerson>,
                SimulationRunner<MotorVehicleSimulationCase, MotorVehiclePerson>>();

            services.AddScoped<IRunCases<MotorVehicleSimulationCase, MotorVehiclePerson>, 
                MotorVehicleCaseRunner>();

            services.AddScoped<IExecuteRules<MotorVehicleSimulationCase, MotorVehiclePerson>,
                MotorVehicleRuleExecutor>();

            services.AddScoped<IGetSimulations<MotorVehicleSimulationCase>, MotorVehicleSimulationGetter>();

            services.AddScoped<ISimulationLib<MotorVehicleSimulationCase>, SimulationLib<MotorVehicleSimulationCase>>();

            services.AddScoped<IStoreSimulations<MotorVehicleSimulationCase>, MotorVehicleSimulationStore>();
        

            // OpenFisca
            services.AddScoped<IOpenFisca, OpenFiscaLib>();
            services.AddScoped<IRestClient, MyRestClient>();

            // OpenFisca options
            var openFiscaUrl = Configuration["OpenFiscaOptions:Url"] ?? 
                Environment.GetEnvironmentVariable("openFiscaUrl");
            var openFiscaOptions = new OpenFiscaOptions() {
                Url = openFiscaUrl
            };
            services.AddSingleton<IOptions<OpenFiscaOptions>>(x => Options.Create(openFiscaOptions));

            services.AddScoped<IBuildDailyRequests, DailyRequestBuilder>();
            services.AddScoped<IBuildAggregateRequests, AggregateRequestBuilder>();
            services.AddScoped<IExtractDailyResults, DailyResultExtractor>();
            services.AddScoped<IExtractAggregateResults, AggregateResultExtractor>();
        }
    }
}
