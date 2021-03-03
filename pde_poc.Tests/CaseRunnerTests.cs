using System;
using System.Collections.Generic;

using Xunit;
using FakeItEasy;

using pde_poc_rule;
using pde_poc_sim;
using Sim = pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;

namespace pde_poc.Tests
{
    public class CaseRunnerTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var personGuid = Guid.NewGuid();

            var person = new Sim.Person() {
                Id = personGuid,
            };

            var simulation = new Sim.SimulationCase() {
                Id = Guid.NewGuid(),
            };

            var persons = new List<Sim.Person>() { person };

            var ruleBuilder = A.Fake<IBuildRules>();
            var simulator = A.Fake<ISimulateMaternityBenefits>();

            var simResult = new Dictionary<Guid, decimal>() {
                { personGuid, 5m }
            };

            A.CallTo(() => simulator
                .Simulate(A<MaternityBenefitRule>._, A<List<Person>>._))
                .Returns(simResult);
            
            var sut = new CaseRunner(ruleBuilder, simulator);

            // Act
            var result = sut.Run(simulation, persons);

            // Assert
            Assert.Single(result.ResultSet);
            Assert.Equal(5m, result.ResultSet[personGuid].Amount);
        }
    }
}
