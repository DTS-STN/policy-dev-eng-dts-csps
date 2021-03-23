using Xunit;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;

namespace pde_poc.Tests
{
    public class MotorVehicleSimulationBuilderTests
    {
        
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            string fakeName = "Sim Name";
            double fakeOtherWeekly = 5;
            double fakeOtherDaily = 6;
            double fakeCmvoWeekly = 8;
            double fakeCmvoDaily = 9;
        
            // Act
            var sut = new MotorVehicleSimulationBuilder();

            var simulationRequest = new SimulationRequest<MotorVehicleSimulationCaseRequest>() {
                BaseCaseRequest = new MotorVehicleSimulationCaseRequest() {
                    StandardCmvoWeekly = fakeCmvoWeekly,
                    StandardCmvoDaily = fakeCmvoDaily
                },
                VariantCaseRequest = new MotorVehicleSimulationCaseRequest() {
                    StandardOtherDaily = fakeOtherDaily,
                    StandardOtherWeekly = fakeOtherWeekly
                },
                SimulationName = fakeName

            };
            var result = sut.Build(simulationRequest);

            // Assert
            Assert.Equal(fakeName, result.Name);
            Assert.Equal(fakeCmvoDaily, result.BaseCase.StandardCmvoDaily);
            Assert.Equal(fakeCmvoWeekly, result.BaseCase.StandardCmvoWeekly);
            Assert.Equal(fakeOtherDaily, result.VariantCase.StandardOtherDaily);
            Assert.Equal(fakeOtherWeekly, result.VariantCase.StandardOtherWeekly);
        }
    }
}
