using System;
using pde_poc_sim.Storage;

namespace pde_poc_sim.Engine.Lib
{
    public class SimulationBuilder : IBuildSimulations
    {
        private readonly IHelperStore _helperStore;

        public SimulationBuilder(IHelperStore helperStore) {
            _helperStore = helperStore;
        }

        public Simulation Build(SimulationRequest simulationRequest) {
            var regionDict = _helperStore.GetBestWeeksDict();

            var baseCase = new SimulationCase() {
                Id = Guid.NewGuid(),
                MaxWeeklyAmount = simulationRequest.BaseCaseRequest.MaxWeeklyAmount,
                Percentage = simulationRequest.BaseCaseRequest.Percentage,
                NumWeeks = simulationRequest.BaseCaseRequest.NumWeeks,
                RegionDict = regionDict
            };

            var variantCase = new SimulationCase() {
                Id = Guid.NewGuid(),
                MaxWeeklyAmount = simulationRequest.VariantCaseRequest.MaxWeeklyAmount,
                Percentage = simulationRequest.VariantCaseRequest.Percentage,
                NumWeeks = simulationRequest.VariantCaseRequest.NumWeeks,
                RegionDict = regionDict
            };

            return new Simulation() {
                Id = Guid.NewGuid(),
                Name = simulationRequest.SimulationName,
                DateCreated = DateTime.Now,
                BaseCase = baseCase,
                VariantCase = variantCase,
            };
        }
    }
}