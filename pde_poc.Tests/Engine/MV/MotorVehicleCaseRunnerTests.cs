using System;
using System.Collections.Generic;

using Xunit;
using FakeItEasy;

using pde_poc_sim.Engine.Interfaces;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;

namespace pde_poc.Tests
{
    public class MotorVehicleCaseRunnerTests
    {
        
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            decimal fakeAmount = 10.5m;
            Guid fakeId = Guid.NewGuid();

            var executor = A.Fake<IExecuteRules<MotorVehicleSimulationCase, MotorVehiclePerson>>();
            A.CallTo(() => executor.Execute(A<MotorVehicleSimulationCase>._, A<MotorVehiclePerson>._)).Returns(fakeAmount);

            // Act
            var sut = new MotorVehicleCaseRunner(executor);

            var simulationCase = A.Fake<MotorVehicleSimulationCase>();
            var persons = new List<MotorVehiclePerson>() {
                new MotorVehiclePerson() {
                    Id = fakeId
                }
            };
            
            var result = sut.Run(simulationCase, persons);

            // Assert
            Assert.Equal(fakeAmount, result.ResultSet[fakeId].Amount);
            Assert.Equal(fakeId, result.ResultSet[fakeId].Person.Id);
        }
    }
}
