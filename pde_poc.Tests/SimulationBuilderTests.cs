using System;
using System.Collections.Generic;

using Xunit;
using FakeItEasy;

using pde_poc_sim;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;
using pde_poc_sim.Storage;

namespace pde_poc.Tests
{
    public class SimulationBuilderTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var helperStore = A.Fake<IHelperStore>();

            var dict = new Dictionary<Guid, UnemploymentRegion>();
            A.CallTo(() => helperStore
                .GetBestWeeksDict())
                .Returns(dict);

            var sut = new SimulationBuilder(helperStore);

            // Act
            var simulationRequest = new SimulationRequest() {
                SimulationName = "Test",
                BaseCaseRequest = new SimulationCaseRequest() {
                    MaxWeeklyAmount = 10,
                    NumWeeks = 5,
                    Percentage = 50
                },
                VariantCaseRequest = new SimulationCaseRequest() {
                    MaxWeeklyAmount = 20,
                    NumWeeks = 10,
                    Percentage = 100
                },
            };

            var result = sut.Build(simulationRequest);

            // Assert
            Assert.Equal("Test", result.Name);
        }
    }
}
