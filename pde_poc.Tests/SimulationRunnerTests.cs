using System;
using System.Collections.Generic;

using Xunit;
using FakeItEasy;

using pde_poc_sim;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;

namespace pde_poc.Tests
{
    public class SimulationRunnerTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var caseRunner = A.Fake<IRunCases>();
            var joiner = A.Fake<IJoinResults>();

            var caseResult = A.Fake<SimulationCaseResult>();

            A.CallTo(() => caseRunner
                .Run(A<SimulationCase>._, A<List<Person>>._))
                .Returns(caseResult)
                .Twice();

            var personResults = new List<PersonResult>() {
                A.Fake<PersonResult>()
            };

            A.CallTo(() => joiner
                .Join(A<SimulationCaseResult>._, A<SimulationCaseResult>._))
                .Returns(personResults);
            
            var sut = new SimulationRunner(caseRunner, joiner);

            // Act
            var simulation = new Simulation();
            var persons = new List<Person>();

            var result = sut.Run(simulation, persons);

            // Assert
            Assert.Single(result.PersonResults);
        }
    }
}
