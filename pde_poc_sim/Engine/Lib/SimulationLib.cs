using System;
using System.Collections.Generic;

using pde_poc_sim.Engine.Interfaces;
using pde_poc_sim.Storage;

namespace pde_poc_sim.Engine.Lib
{
    public class SimulationLib<T>: ISimulationLib<T>
        where T : ISimulationCase
    {
        private readonly IHelperStore<T> _helperStore;
        private readonly IStoreSimulations<T> _simulationStore;

        public SimulationLib(
            IHelperStore<T> helperStore, 
            IStoreSimulations<T> simulationStore
        ) {
            _helperStore = helperStore;
            _simulationStore = simulationStore;
        }

        public T GetBaseCase() {
            return _helperStore.GetBaseCase();
        }

        public IEnumerable<SimulationLite> GetAll() {
            return _simulationStore.GetAll();
        }

        public void DeleteSimulation(Guid id) {
            _simulationStore.Delete(id);
        }
    }
}