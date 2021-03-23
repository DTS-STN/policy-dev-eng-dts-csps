using System;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public interface IGetSimulations<T> where T : ISimulationCase
    {
        SimulationFull<T> Get(Guid simulationId);
    }
}