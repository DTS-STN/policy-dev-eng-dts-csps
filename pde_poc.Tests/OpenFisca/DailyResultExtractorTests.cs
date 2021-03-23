using System;
using Xunit;

using pde_poc_sim.OpenFisca;

using OF = pde_poc_sim.OpenFisca.OpenFiscaVariables;


namespace pde_poc.Tests
{
    public class DailyResultExtractorTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            decimal expectedResult = 10m;
            var response = BuildResponse(expectedResult);

            // Act
            var sut = new DailyResultExtractor();
            var result = sut.Extract(response);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        private OpenFiscaResource BuildResponse(decimal expectedResult) {
            var day1Key = "day_1";
            var day2Key = "day_2";
            double day1Val = (double)expectedResult - 5;
            double day2Val = 5;
            var result = new OpenFiscaResource();

            result.CreatePerson(day1Key);
            result.CreatePerson(day2Key);
            result.SetProp(day1Key, OF.DailyOTHours, day1Val);
            result.SetProp(day2Key, OF.DailyOTHours, day2Val);
            return result;
        }
    }
}
