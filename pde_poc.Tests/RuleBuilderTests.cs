using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using FakeItEasy;

using pde_poc_sim;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;
using pde_poc.Tests.Builders;

namespace pde_poc.Tests
{
    public class RuleBuilderTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var id1 = Guid.NewGuid();
            var region1 = new UnemploymentRegion() {
                Id = id1,
                BestWeeks = 10
            };

            var id2 = Guid.NewGuid();
            var region2 = new UnemploymentRegion() {
                Id = id2,
                BestWeeks = 20
            };

            var regionDict = new Dictionary<Guid, UnemploymentRegion>() {
                {id1, region1},
                {id2, region2}
            };
            
            var simulationCase = new SimulationCase() {
                Id = Guid.NewGuid(),
                Percentage = 20.5,
                MaxWeeklyAmount = 999.999m,
                NumWeeks = 10,
                RegionDict = regionDict,
            };

            var sut = new RuleBuilder();

            // Act
            sut.Build(simulationCase);

            // Assert
            // TODO: Need a way to measure this...
            Assert.True(true);
        }
    }
}
