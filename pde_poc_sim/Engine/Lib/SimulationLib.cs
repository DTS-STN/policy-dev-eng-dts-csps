using System;
using System.Collections.Generic;

using pde_poc_sim.Storage;

namespace pde_poc_sim.Engine.Lib
{
    public class SimulationLib: ISimulationLib
    {
        private readonly IHelperStore _helperStore;
        private readonly IStoreSimulations _simulationStore;

        public SimulationLib(
            IHelperStore helperStore, 
            IStoreSimulations simulationStore
        ) {
            _helperStore = helperStore;
            _simulationStore = simulationStore;
        }

        public SimulationCase GetBaseCase() {
            return _helperStore.GetBaseCase();
        }

        public List<SimulationLite> GetAll() {
            return _simulationStore.GetAll();
        }

        public void DeleteSimulation(Guid id) {
            _simulationStore.Delete(id);
        }
    }
}