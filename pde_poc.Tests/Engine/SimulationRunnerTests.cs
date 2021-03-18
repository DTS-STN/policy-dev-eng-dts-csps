using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using FakeItEasy;

using pde_poc_sim;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;
using pde_poc_sim.Storage;
using pde_poc_sim.Engine.Interfaces;
using pde_poc.Tests.Builders;

namespace pde_poc.Tests
{
    public class SimulationRunnerTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var caseRunner = A.Fake<IRunCases<ISimulationCase, IPerson>>();
            var joiner = A.Fake<IJoinResults>();

            var personResults = new List<PersonResult>() {
                new PersonResult()
            };
            A.CallTo(() => joiner.Join(A<SimulationCaseResult>._, A<SimulationCaseResult>._))
                .Returns(personResults);
            

            // Act
            var sut = new SimulationRunner<ISimulationCase, IPerson>(caseRunner, joiner);

            var simulation = A.Fake<Simulation<ISimulationCase>>();
            var persons = new List<IPerson>() {
                A.Fake<IPerson>()
            };

            var result = sut.Run(simulation, persons);

            // Assert
            A.CallTo(() => caseRunner.Run(A<ISimulationCase>._, A<IEnumerable<IPerson>>._)).MustHaveHappenedTwiceExactly();
            A.CallTo(() => joiner.Join(A<SimulationCaseResult>._, A<SimulationCaseResult>._)).MustHaveHappenedOnceExactly();

            Assert.Single(result.PersonResults);
        }
    }
}
