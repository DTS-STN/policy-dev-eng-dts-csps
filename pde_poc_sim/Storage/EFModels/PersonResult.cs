using System;
using System.Collections.Generic;

namespace pde_poc_sim.Storage.EFModels
{
    public class PersonResult
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid SimulationResultId { get; set; }
        public SimulationResult SimulationResult { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal VariantAmount { get; set; }
    }
}