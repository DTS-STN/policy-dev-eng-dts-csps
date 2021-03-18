using System;
using System.Collections.Generic;
using pde_poc_sim.Storage;

namespace pde_poc_sim.Engine.Lib
{
    public class MotorVehicleSimulationGetter : IGetSimulations<MotorVehicleSimulationCase>
    {
        private readonly IStoreSimulations<MotorVehicleSimulationCase> _simulationStore;

        public MotorVehicleSimulationGetter(
            IStoreSimulations<MotorVehicleSimulationCase> simulationStore
        ) {
                _simulationStore = simulationStore;
        }

        public SimulationFull<MotorVehicleSimulationCase> Get(Guid simulationId) {
            var simulation = _simulationStore.GetSimulation(simulationId);

            var simulationResult = _simulationStore.GetSimulationResult(simulationId);

            return new SimulationFull<MotorVehicleSimulationCase>() {
                Simulation = simulation,
                SimulationResult = simulationResult,
                AggregationResults = new List<AggregationResult>() {
                },

            };
        }


    }
}