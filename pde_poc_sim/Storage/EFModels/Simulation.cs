using System;
using System.Collections.Generic;

namespace pde_poc_sim.Storage.EFModels
{
    // Dont use this for now...
    public class Simulation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BaseCaseId { get; set; }
        public Case BaseCase { get; set; }
        public Guid VariantCaseId { get; set; }
        public Case VariantCase { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }

        // public Guid SimulationResultId { get; set; }
        // public SimulationResult SimulationResult { get; set; }
    }
}