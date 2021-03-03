using System;
using System.Collections.Generic;
using pde_poc_sim.Storage;

namespace pde_poc_sim.Engine.Lib
{
    public class SimulationGetter : IGetSimulations
    {
        private readonly IStoreSimulations _simulationStore;
        private readonly IAggregateDemographics _demographicAggregator;

        public SimulationGetter(
            IStoreSimulations simulationStore,
            IAggregateDemographics demographicsAggregator
        ) {
                _simulationStore = simulationStore;
                _demographicAggregator = demographicsAggregator;
        }

        public SimulationFull Get(Guid simulationId) {
            var simulation = _simulationStore.GetSimulation(simulationId);

            var simulationResult = _simulationStore.GetSimulationResult(simulationId);

            var regionAggregate = _demographicAggregator.AggregateRegion(simulationResult.PersonResults);

            return new SimulationFull() {
                Simulation = simulation,
                SimulationResult = simulationResult,
                AggregationResults = new List<AggregationResult>() {
                    regionAggregate
                },

            };
        }


    }
}