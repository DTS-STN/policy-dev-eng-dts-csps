using System;
using System.Collections.Generic;

using Xunit;
using FakeItEasy;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;
using pde_poc_sim.Storage;

namespace pde_poc.Tests
{
    public class MotorVehicleSimulationGetterTests
    {
        
        [Fact]
        public void ShouldWorkNormally()
        {

            // Arrange
            var fakeId = Guid.NewGuid();
            var fakeName = "Test Sim";
            var fakeDate = new DateTime(2020, 3, 22);
            var simulationStore = A.Fake<IStoreSimulations<MotorVehicleSimulationCase>>();

            var simulation = new Simulation<MotorVehicleSimulationCase>() {
                Name = fakeName,
                DateCreated = fakeDate
            };
            A.CallTo(() => simulationStore.GetSimulation(fakeId))
                .Returns(simulation);

            var simulationResult = new SimulationResult() {
                PersonResults = new List<PersonResult>(){
                    new PersonResult() 
                }
            };
            A.CallTo(() => simulationStore.GetSimulationResult(fakeId))
                .Returns(simulationResult);
        
            // Act
            var sut = new MotorVehicleSimulationGetter(simulationStore);

            var result = sut.Get(fakeId);

            // Assert
            Assert.Equal(fakeName, result.Simulation.Name);
            Assert.Equal(fakeDate, result.Simulation.DateCreated);
            Assert.Single(result.SimulationResult.PersonResults);
        }
    }
}
