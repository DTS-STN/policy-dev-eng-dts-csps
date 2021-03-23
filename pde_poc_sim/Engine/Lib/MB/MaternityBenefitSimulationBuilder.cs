using System;
using pde_poc_sim.Storage;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public class MaternityBenefitSimulationBuilder : IBuildSimulations<MaternityBenefitSimulationCase, MaternityBenefitSimulationCaseRequest>
    {
        private readonly IHelperStore<MaternityBenefitSimulationCase> _helperStore;

        public MaternityBenefitSimulationBuilder(IHelperStore<MaternityBenefitSimulationCase> helperStore) {
            _helperStore = helperStore;
        }

        public Simulation<MaternityBenefitSimulationCase> Build(SimulationRequest<MaternityBenefitSimulationCaseRequest> simulationRequest) {
            var regionDict = _helperStore.GetBestWeeksDict();

            var baseCase = new MaternityBenefitSimulationCase() {
                Id = Guid.NewGuid(),
                MaxWeeklyAmount = simulationRequest.BaseCaseRequest.MaxWeeklyAmount,
                Percentage = simulationRequest.BaseCaseRequest.Percentage,
                NumWeeks = simulationRequest.BaseCaseRequest.NumWeeks,
                RegionDict = regionDict
            };

            var variantCase = new MaternityBenefitSimulationCase() {
                Id = Guid.NewGuid(),
                MaxWeeklyAmount = simulationRequest.VariantCaseRequest.MaxWeeklyAmount,
                Percentage = simulationRequest.VariantCaseRequest.Percentage,
                NumWeeks = simulationRequest.VariantCaseRequest.NumWeeks,
                RegionDict = regionDict
            };

            return new Simulation<MaternityBenefitSimulationCase>() {
                Id = Guid.NewGuid(),
                Name = simulationRequest.SimulationName,
                DateCreated = DateTime.Now,
                BaseCase = baseCase,
                VariantCase = variantCase,
            };
        }
    }
}