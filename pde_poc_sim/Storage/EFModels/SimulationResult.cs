using System;
using System.Collections.Generic;

namespace pde_poc_sim.Storage.EFModels
{
    public class SimulationResult
    {
        public Guid Id { get; set; }
        public Guid SimulationId { get; set; }
        public Simulation Simulation { get; set; } 
        public List<PersonResult> PersonResults { get; set; }

    }
}