using System;

using pde_poc_sim.Storage;

namespace pde_poc_sim.Engine.Lib
{
    public class SimulationRequestHandler: IHandleSimulationRequests
    {
        private readonly IBuildSimulations _simulationBuilder;
        private readonly IStoreSimulations _simulationStore;
        private readonly IRunSimulations _runner;
        private readonly IHelperStore _helperStore;

        public SimulationRequestHandler(
            IBuildSimulations simulationBuilder, 
            IStoreSimulations simulationStore,
            IRunSimulations runner,
            IHelperStore helperStore
        ) {
            _simulationBuilder = simulationBuilder;
            _simulationStore = simulationStore;
            _runner = runner;
            _helperStore = helperStore;
        }

        public Guid Handle(SimulationRequest request) {
            var simulation = _simulationBuilder.Build(request);

            _simulationStore.SaveSimulation(simulation);
            
            var persons = _helperStore.GetAllPersons();
            var result = _runner.Run(simulation, persons);

            _simulationStore.StoreResults(simulation.Id, result);

            return simulation.Id;
        }
    }
}