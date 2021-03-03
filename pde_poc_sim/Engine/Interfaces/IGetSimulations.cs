using System;

namespace pde_poc_sim.Engine.Lib
{
    public interface IGetSimulations
    {
        SimulationFull Get(Guid simulationId);
    }
}