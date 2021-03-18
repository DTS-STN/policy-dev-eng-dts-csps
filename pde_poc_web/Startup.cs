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

// using pde_poc_web.Models.Storage;
// using pde_poc_web.Models.Storage.Mocks;
// using pde_poc_web.Models.Engine.Lib;


using pde_poc_sim.Storage;
using pde_poc_sim.Storage.Mocks;
using pde_poc_sim.Engine.Lib;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;
using Rule = pde_poc_rule;

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
            string connectionString = Configuration.GetConnectionString("DefaultDB");
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
                    pattern: "{controller=Simulation}/{action=Form}/{id?}");
            });
        }
   

        private void InjectMaternityBenefits(IServiceCollection services) {
            services.AddScoped<IHandleSimulationRequests<MaternityBenefitSimulationCaseRequest>, 
                SimulationRequestHandler<
                    MaternityBenefitSimulationCase, 
                    MaternityBenefitSimulationCaseRequest, 
                    pde_poc_sim.Engine.MaternityBenefitPerson
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

            services.AddScoped<IBuildRules<MaternityBenefitSimulationCase, Rule.MaternityBenefitPerson>,
                MaternityBenefitRuleBuilder>();

            services.AddScoped<IGetSimulations<MaternityBenefitSimulationCase>, MaternityBenefitSimulationGetter>();

            services.AddScoped<ISimulationLib<MaternityBenefitSimulationCase>, SimulationLib<MaternityBenefitSimulationCase>>();

            services.AddScoped<IStoreSimulations<MaternityBenefitSimulationCase>, MaternityBenefitSimulationStore>();

            // Executor
            services.AddScoped<Rule.IExecuteRules<Rule.MaternityBenefitPerson>, Rule.RuleExecutor<Rule.MaternityBenefitPerson>>();

            

        }

        private void InjectMotorVehicle(IServiceCollection services) {
            services.AddScoped<IHandleSimulationRequests<MotorVehicleSimulationCaseRequest>, 
                SimulationRequestHandler<
                    MotorVehicleSimulationCase, 
                    MotorVehicleSimulationCaseRequest, 
                    pde_poc_sim.Engine.MotorVehiclePerson
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

            services.AddScoped<IBuildRules<MotorVehicleSimulationCase, Rule.MotorVehiclePerson>,
                MotorVehicleRuleBuilder>();

            services.AddScoped<IGetSimulations<MotorVehicleSimulationCase>, MotorVehicleSimulationGetter>();

            services.AddScoped<ISimulationLib<MotorVehicleSimulationCase>, SimulationLib<MotorVehicleSimulationCase>>();

            services.AddScoped<IStoreSimulations<MotorVehicleSimulationCase>, MotorVehicleSimulationStore>();


            services.AddScoped<Rule.IExecuteRules<Rule.MotorVehiclePerson>, Rule.RuleExecutor<Rule.MotorVehiclePerson>>();

        }
    }
}
