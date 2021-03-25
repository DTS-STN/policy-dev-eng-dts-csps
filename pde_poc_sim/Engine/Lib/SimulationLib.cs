using System;
using System.Collections.Generic;

using pde_poc_sim.Engine.Interfaces;
using pde_poc_sim.Storage;

namespace pde_poc_sim.Engine.Lib
{
    public class SimulationLib<T>: ISimulationLib<T>
        where T : ISimulationCase
    {
        private readonly IStoreSimulations<T> _simulationStore;

        public SimulationLib(
            IStoreSimulations<T> simulationStore
        ) {
            _simulationStore = simulationStore;
        }

        public IEnumerable<SimulationLite> GetAll() {
            return _simulationStore.GetAll();
        }

        public void DeleteSimulation(Guid id) {
            _simulationStore.Delete(id);
        }
    }
}