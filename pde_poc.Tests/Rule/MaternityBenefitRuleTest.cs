using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FakeItEasy;

using pde_poc_rule;

namespace pde_poc.Tests
{
    public class MaternityBenefitRuleTest
    {
        [Fact]
        public void ShouldUseFullCalculation()
        {
            // Arrange
            var bestWeeks = GenerateBestWeeks();
            var sut = new MaternityBenefitRule(50d, 5, 600m, bestWeeks);

            var person = A.Fake<IPerson>();
            person.Id = Guid.NewGuid();
            person.UnemploymentRegionId = bestWeeks.First().Key;

            A.CallTo(() => person.GetAverageIncome(A<int>._)).Returns(1000m);
            
            // Act
            var result = sut.Calculate(person);

            // Assert
            Assert.Equal(2500, result);
        }

        [Fact]
        public void ShouldUseMaxValue()
        {
            // Arrange
            var bestWeeks = GenerateBestWeeks();
            var sut = new MaternityBenefitRule(50d, 5, 400m, bestWeeks);

            var person = A.Fake<IPerson>();
            person.Id = Guid.NewGuid();
            person.UnemploymentRegionId = bestWeeks.First().Key;

            A.CallTo(() => person.GetAverageIncome(A<int>._)).Returns(1000m);
            
            // Act
            var result = sut.Calculate(person);

            // Assert
            Assert.Equal(2000, result);
        }

        private Dictionary<Guid, int> GenerateBestWeeks() {
            var bestWeeksDict = new Dictionary<Guid, int>() {
                { Guid.NewGuid(), 10 }, 
            };

            return bestWeeksDict;
        }
    }
}
