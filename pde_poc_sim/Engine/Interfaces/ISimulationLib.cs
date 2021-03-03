using System;
using System.Collections.Generic;

namespace pde_poc_sim.Engine.Lib
{
    public interface ISimulationLib
    {
         SimulationCase GetBaseCase();
         List<SimulationLite> GetAll();
         void DeleteSimulation(Guid id);
    }
}