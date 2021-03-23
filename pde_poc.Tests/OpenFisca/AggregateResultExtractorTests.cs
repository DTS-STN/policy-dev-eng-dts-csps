using System;
using System.Collections.Generic;
using Xunit;

using pde_poc_sim.Engine;
using pde_poc_sim.OpenFisca;

using OF = pde_poc_sim.OpenFisca.OpenFiscaVariables;


namespace pde_poc.Tests
{
    public class AggregateResultExtractorTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            decimal expectedResult = 15m;
            var response = BuildResponse(expectedResult);

            // // Act
            var sut = new AggregateResultExtractor();
            var result = sut.Extract(response);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        private OpenFiscaResource BuildResponse(decimal expectedResult) {
            var result = new OpenFiscaResource();
            string personKey = "person1";
            result.CreatePerson(personKey);
            result.SetProp(personKey, OF.TotalOTHours,expectedResult);
            return result;
        }
    }
}
