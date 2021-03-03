using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using FakeItEasy;

using pde_poc_sim;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;
using pde_poc_sim.Storage;
using pde_poc.Tests.Builders;

namespace pde_poc.Tests
{
    public class SimulationGetterTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var simulationId = Guid.NewGuid();
            var simStore = A.Fake<IStoreSimulations>();
            var demographicsAggregator = A.Fake<IAggregateDemographics>();

            var simulation = new Simulation() {
                Id = simulationId,
                Name = "TEST"
            };

            var simulationResult = new SimulationResult() {
                PersonResults = new List<PersonResult>()
            };

            var regionAggregate = A.Fake<AggregationResult>();

            A.CallTo(() => simStore
                .GetSimulation(simulationId))
                .Returns(simulation);
            
            A.CallTo(() => simStore
                .GetSimulationResult(simulationId))
                .Returns(simulationResult);
            
            A.CallTo(() => demographicsAggregator
                .AggregateRegion(A<List<PersonResult>>._))
                .Returns(regionAggregate);
            
            var sut = new SimulationGetter(simStore, demographicsAggregator);

            // Act
            var result = sut.Get(simulationId);

            // Assert
            Assert.Equal("TEST", result.Simulation.Name);
            Assert.Equal(simulationId, result.Simulation.Id);
            Assert.Single(result.AggregationResults);
        }
    }
}
