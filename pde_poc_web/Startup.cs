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
using pde_poc_rule;

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
            services.AddScoped<IHelperStore, HelperStore>();
            services.AddScoped<IStoreSimulations, SimulationStore>();

            // Lib
            services.AddScoped<ISimulationLib, SimulationLib>();
            services.AddScoped<IHandleSimulationRequests, SimulationRequestHandler>();
            services.AddScoped<IRunSimulations, SimulationRunner>();
            services.AddScoped<IRunCases, CaseRunner>();
            services.AddScoped<IBuildRules, RuleBuilder>();
            services.AddScoped<IJoinResults, Joiner>();
            services.AddScoped<IGetSimulations, SimulationGetter>();
            services.AddScoped<IBuildSimulations, SimulationBuilder>();
            services.AddScoped<IAggregateDemographics, DemographicsAggregator>();
            services.AddScoped<ISimulateMaternityBenefits, MaternityBenefitSimulator>();

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
    }
}
