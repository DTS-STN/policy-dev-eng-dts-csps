using System;
using Microsoft.EntityFrameworkCore;

using pde_poc_sim.Storage.EFModels;

namespace pde_poc_sim.Storage
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            // Empty constructor body...
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<EFModels.UnemploymentRegion> UnemploymentRegions { get; set; }
        public DbSet<EFModels.Person> Persons { get; set; }
        public DbSet<EFModels.Case> Cases { get; set; }
        public DbSet<EFModels.Simulation> Simulations { get; set; }
        public DbSet<EFModels.SimulationResult> SimulationResults { get; set; }
        public DbSet<EFModels.PersonResult> PersonResults { get; set; }
    }
}