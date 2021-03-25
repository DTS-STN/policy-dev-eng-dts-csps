using System;
using System.Collections.Generic;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public interface ISimulationLib<T> where T : ISimulationCase
    {
         IEnumerable<SimulationLite> GetAll();
         void DeleteSimulation(Guid id);
    }
}