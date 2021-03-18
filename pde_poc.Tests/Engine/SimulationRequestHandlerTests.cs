using System;
using System.Collections.Generic;

using Xunit;
using FakeItEasy;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;
using pde_poc_sim.Storage;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc.Tests
{
    public class SimulationRequestHandlerTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var simulationStore = A.Fake<IStoreSimulations<ISimulationCase>>();
            var personStore = A.Fake<IStorePersons<IPerson>>();
            var runner = A.Fake<IRunSimulations<ISimulationCase, IPerson>>();
            var simulationBuilder = A.Fake<IBuildSimulations<ISimulationCase, ISimulationCaseRequest>>();

            var testId = Guid.NewGuid();
            var simulation = new Simulation<ISimulationCase>() {
                Id = testId
            };
            A.CallTo(() => simulationBuilder.Build(A<SimulationRequest<ISimulationCaseRequest>>._)).Returns(simulation);
            
            
            // Act
            var sut = new SimulationRequestHandler<
                ISimulationCase, 
                ISimulationCaseRequest, 
                IPerson>
                (simulationBuilder, simulationStore, personStore, runner);

            var request = new SimulationRequest<ISimulationCaseRequest>();
            
            var result = sut.Handle(request);


            // Assert
            A.CallTo(() => simulationBuilder.Build(A<SimulationRequest<ISimulationCaseRequest>>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => simulationStore.SaveSimulation(A<Simulation<ISimulationCase>>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => personStore.GetAllPersons()).MustHaveHappenedOnceExactly();
            A.CallTo(() => runner.Run(A<Simulation<ISimulationCase>>._, A<IEnumerable<IPerson>>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => simulationStore.StoreResults(testId, A<SimulationResult>._)).MustHaveHappenedOnceExactly();
            
            Assert.Equal(result, testId);
        }
    }
}
