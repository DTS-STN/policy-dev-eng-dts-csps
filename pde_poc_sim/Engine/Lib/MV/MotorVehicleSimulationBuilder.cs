using System;

namespace pde_poc_sim.Engine.Lib
{
    public class MotorVehicleSimulationBuilder : IBuildSimulations<MotorVehicleSimulationCase, MotorVehicleSimulationCaseRequest>
    {
        public Simulation<MotorVehicleSimulationCase> Build(SimulationRequest<MotorVehicleSimulationCaseRequest> simulationRequest) {
            return new Simulation<MotorVehicleSimulationCase>() {
                Id = Guid.NewGuid(),
                Name = simulationRequest.SimulationName,
                DateCreated = DateTime.Now,
                BaseCase = new MotorVehicleSimulationCase(simulationRequest.BaseCaseRequest),
                VariantCase = new MotorVehicleSimulationCase(simulationRequest.VariantCaseRequest),
            };
        }
    }
}