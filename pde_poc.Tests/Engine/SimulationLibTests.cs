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
    public class SimulationLibTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var simulationStore = A.Fake<IStoreSimulations<ISimulationCase>>();
            var helperStore = A.Fake<IHelperStore<ISimulationCase>>();

            var simulations = new List<SimulationLite>() {
                new SimulationLite()
            };
            A.CallTo(() => simulationStore.GetAll()).Returns(simulations);
            

            // Act
            var sut = new SimulationLib<ISimulationCase>(helperStore, simulationStore);

            var result = sut.GetAll();


            // Assert
            A.CallTo(() => simulationStore.GetAll()).MustHaveHappenedOnceExactly();

            Assert.Single(result);
        }
    }
}
