
using System;
using System.Collections.Generic;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Storage
{
    public interface IStoreSimulations<T> where T : ISimulationCase
    {
        void SaveSimulation(Simulation<T> simulation);
        void StoreResults(Guid simulationId, SimulationResult simulationResult);
        Simulation<T> GetSimulation(Guid id);
        SimulationResult GetSimulationResult(Guid simulationId);
        IEnumerable<SimulationLite> GetAll();
        void Delete(Guid id);
    }
}