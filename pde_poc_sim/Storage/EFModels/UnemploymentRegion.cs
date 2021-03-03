using System;

namespace pde_poc_sim.Storage.EFModels
{
    public class UnemploymentRegion
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public string Province { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double UnemploymentRate { get; set; }

        public DateTime LastUpdated { get; set; }

        public int BestWeeks { get; set; }
    }
}