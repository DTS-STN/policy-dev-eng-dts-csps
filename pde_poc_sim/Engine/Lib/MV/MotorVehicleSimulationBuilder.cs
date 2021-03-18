using System;
using pde_poc_sim.Storage;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public class MotorVehicleSimulationBuilder : IBuildSimulations<MotorVehicleSimulationCase, MotorVehicleSimulationCaseRequest>
    {

        public Simulation<MotorVehicleSimulationCase> Build(SimulationRequest<MotorVehicleSimulationCaseRequest> simulationRequest) {

            var baseCase = new MotorVehicleSimulationCase() {
                Id = Guid.NewGuid(),
                StandardCmvoDaily = simulationRequest.BaseCaseRequest.StandardCmvoDaily,
                StandardCmvoWeekly = simulationRequest.BaseCaseRequest.StandardCmvoWeekly,
                StandardOtherDaily = simulationRequest.BaseCaseRequest.StandardOtherDaily,
                StandardOtherWeekly = simulationRequest.BaseCaseRequest.StandardOtherWeekly,
                StandardHighwayWeekly = simulationRequest.BaseCaseRequest.StandardHighwayWeekly,
                StandardHighwayReduction = simulationRequest.BaseCaseRequest.StandardHighwayReduction,
                MaxCmvoDistance = simulationRequest.BaseCaseRequest.MaxCmvoDistance,
            };

            var variantCase = new MotorVehicleSimulationCase() {
                Id = Guid.NewGuid(),
                StandardCmvoDaily = simulationRequest.VariantCaseRequest.StandardCmvoDaily,
                StandardCmvoWeekly = simulationRequest.VariantCaseRequest.StandardCmvoWeekly,
                StandardOtherDaily = simulationRequest.VariantCaseRequest.StandardOtherDaily,
                StandardOtherWeekly = simulationRequest.VariantCaseRequest.StandardOtherWeekly,
                StandardHighwayWeekly = simulationRequest.VariantCaseRequest.StandardHighwayWeekly,
                StandardHighwayReduction = simulationRequest.VariantCaseRequest.StandardHighwayReduction,
                MaxCmvoDistance = simulationRequest.VariantCaseRequest.MaxCmvoDistance,
            };

            return new Simulation<MotorVehicleSimulationCase>() {
                Id = Guid.NewGuid(),
                Name = simulationRequest.SimulationName,
                DateCreated = DateTime.Now,
                BaseCase = baseCase,
                VariantCase = variantCase,
            };
        }
    }
}