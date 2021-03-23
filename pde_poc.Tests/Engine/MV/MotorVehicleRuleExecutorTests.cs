using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using FakeItEasy;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;

using pde_poc_sim.OpenFisca;

namespace pde_poc.Tests
{
    public class MotorVehicleRuleExecutorTests
    {
        
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            decimal fakeDailyResult = 9m;
            decimal fakeAggregateResult = 10m;

            var openFiscaLib = A.Fake<IOpenFisca>();
            var dailyRequestBuilder = A.Fake<IBuildDailyRequests>();
            var aggregateRequestBuilder = A.Fake<IBuildAggregateRequests>();
            var dailyResultExtractor = A.Fake<IExtractDailyResults>();
            var aggregateResultExtractor = A.Fake<IExtractAggregateResults>();

            A.CallTo(() => dailyResultExtractor.Extract(A<OpenFiscaResource>._))
                .Returns(fakeDailyResult);

            A.CallTo(() => aggregateResultExtractor.Extract(A<OpenFiscaResource>._))
                .Returns(fakeAggregateResult);
            
            // Act
            var sut = new MotorVehicleRuleExecutor(
                openFiscaLib, 
                dailyRequestBuilder, 
                aggregateRequestBuilder,
                dailyResultExtractor,
                aggregateResultExtractor);

            var simulationCase = A.Fake<MotorVehicleSimulationCase>();
            var person = new MotorVehiclePerson();
            
            var result = sut.Execute(simulationCase, person);

            // Assert
            A.CallTo(() => openFiscaLib.Calculate(A<OpenFiscaResource>._))
                .MustHaveHappenedTwiceExactly();
            A.CallTo(() => dailyRequestBuilder.Build(A<MotorVehicleSimulationCase>._, A<MotorVehiclePerson>._))
                .MustHaveHappenedOnceExactly();
            A.CallTo(() => aggregateRequestBuilder.Build(A<MotorVehicleSimulationCase>._, A<MotorVehiclePerson>._, fakeDailyResult))
                .MustHaveHappenedOnceExactly();
            A.CallTo(() => dailyResultExtractor.Extract(A<OpenFiscaResource>._))
                .MustHaveHappenedOnceExactly();
            A.CallTo(() => aggregateResultExtractor.Extract(A<OpenFiscaResource>._))
                .MustHaveHappenedOnceExactly();

            // Could just make sure calls happened
            Assert.Equal(fakeAggregateResult, result);
        }
    }
}
