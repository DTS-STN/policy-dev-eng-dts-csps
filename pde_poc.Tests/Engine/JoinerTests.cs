using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using FakeItEasy;

using pde_poc_sim;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;
using pde_poc.Tests.Builders;

namespace pde_poc.Tests
{
    public class JoinerTests
    {
        
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            decimal testBaseAmount = 1.5m;
            decimal testVariantAmount = 0m;
            var personId = Guid.NewGuid();
            var baseResult = GenerateCaseResult(personId, testBaseAmount);
            var variantResult = GenerateCaseResult(personId, testVariantAmount);


            // Act
            var sut = new Joiner();
            
            var result = sut.Join(baseResult, variantResult);


            // Assert
            Assert.Single(result);
            var pcr1 = result.First(x => x.BaseAmount == 1.5m && x.VariantAmount == 0);
            Assert.NotNull(pcr1);
        }


        private SimulationCaseResult GenerateCaseResult(Guid personId, decimal amount) {
            var pcr1 = new PersonCaseResult() {
                Person = PersonBuilder.Generate(personId),
                Amount = amount
            };

            var dict = new Dictionary<Guid, PersonCaseResult>() {
                {
                    pcr1.Person.Id,
                    pcr1
                }
            };
            
            return new SimulationCaseResult() {
                ResultSet = dict
            };
        }
    }
}
