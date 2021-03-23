using System;
using System.Collections.Generic;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine
{
    public class SimulationFull<T> where T : ISimulationCase
    {
        public Simulation<T> Simulation { get; set; }
        public SimulationResult SimulationResult { get; set; }
        public IEnumerable<AggregationResult> AggregationResults { get; set; }
    }
}