using System;
using System.Collections.Generic;

namespace pde_poc_sim.Engine.Interfaces
{
    public interface ISimulationFull<T,U>
        where T : ISimulation<U>
        where U : ISimulationCase
    {
        T Simulation { get; set; }
        SimulationResult SimulationResult { get; set; }
        IEnumerable<AggregationResult> AggregationResults { get; set; }
    }
}