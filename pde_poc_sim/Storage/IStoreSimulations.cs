
using System;
using System.Collections.Generic;

using pde_poc_sim.Engine;

namespace pde_poc_sim.Storage
{
    public interface IStoreSimulations
    {
        void SaveSimulation(Simulation simulation);
        void StoreResults(Guid simulationId, SimulationResult simulationResult);
        Simulation GetSimulation(Guid id);
        SimulationResult GetSimulationResult(Guid simulationId);
        List<SimulationLite> GetAll();
        void Delete(Guid id);
    }
}