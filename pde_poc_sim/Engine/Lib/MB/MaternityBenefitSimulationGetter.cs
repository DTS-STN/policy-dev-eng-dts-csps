using System;
using System.Collections.Generic;
using pde_poc_sim.Storage;

namespace pde_poc_sim.Engine.Lib
{
    public class MaternityBenefitSimulationGetter : IGetSimulations<MaternityBenefitSimulationCase>
    {
        private readonly IStoreSimulations<MaternityBenefitSimulationCase> _simulationStore;

        public MaternityBenefitSimulationGetter(
            IStoreSimulations<MaternityBenefitSimulationCase> simulationStore
        ) {
                _simulationStore = simulationStore;
        }

        public SimulationFull<MaternityBenefitSimulationCase> Get(Guid simulationId) {
            var simulation = _simulationStore.GetSimulation(simulationId);

            var simulationResult = _simulationStore.GetSimulationResult(simulationId);

            return new SimulationFull<MaternityBenefitSimulationCase>() {
                Simulation = simulation,
                SimulationResult = simulationResult,
                AggregationResults = new List<AggregationResult>() {
                },

            };
        }


    }
}