using System;
using System.Collections.Generic;

using Xunit;
using FakeItEasy;

using pde_poc_rule;
using pde_poc_sim;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;
using pde_poc_sim.Storage;

namespace pde_poc.Tests
{
    public class SimulationRequestHandlerTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var simulationBuilder = A.Fake<IBuildSimulations>();
            var helperStore = A.Fake<IHelperStore>();
            var simulationStore = A.Fake<IStoreSimulations>();
            var simulationRunner = A.Fake<IRunSimulations>();
            
            var sut = new SimulationRequestHandler(simulationBuilder, simulationStore, simulationRunner, helperStore);

            // Act
            var request = new SimulationRequest() {
                SimulationName = "Test",
                BaseCaseRequest = new SimulationCaseRequest(),
                VariantCaseRequest = new SimulationCaseRequest(),
            };
            var result = sut.Handle(request);

            // Assert
            Assert.True(true);
        }
    }
}
