using System;
using System.Collections.Generic;

namespace pde_poc_sim.Engine
{
    public class SimulationFull
    {
        public Simulation Simulation { get; set; }
        public SimulationResult SimulationResult { get; set; }
        public List<AggregationResult> AggregationResults { get; set; }
    }
}