using System;
using System.Collections.Generic;

using Xunit;
using FakeItEasy;

using pde_poc_sim;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;

namespace pde_poc.Tests
{
    public class DemographicsAggregatorTests
    {
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var personResults = GeneratePersonResults();
        
            var sut = new DemographicsAggregator();

            // Act
            var result = sut.AggregateRegion(personResults);

            // Assert
            Assert.Equal(1, result.Dict["SK"].Gainers);
            Assert.Equal(1, result.Dict["SK"].Neutral);
            Assert.Equal(1, result.Dict["AB"].Losers);
            Assert.Equal(1, result.Dict["AB"].Neutral);
            Assert.Equal(2, result.Dict["BC"].Neutral);
            Assert.Equal("Region", result.Name);
        }


        private List<PersonResult> GeneratePersonResults() {
            var p1 = new Person() {
                Id = Guid.NewGuid(),
                UnemploymentRegion = new UnemploymentRegion() {
                    Id = Guid.NewGuid(),
                    Province = "SK"
                }
            };

            var pr1 = new PersonResult() {
                Person = p1,
                BaseAmount = 0,
                VariantAmount = 1
            };

            var p2 = new Person() {
                Id = Guid.NewGuid(),
                UnemploymentRegion = new UnemploymentRegion() {
                    Id = Guid.NewGuid(),
                    Province = "SK"
                }
            };

            var pr2 = new PersonResult() {
                Person = p2,
                BaseAmount = 0,
                VariantAmount = 0
            };

            var p3 = new Person() {
                Id = Guid.NewGuid(),
                UnemploymentRegion = new UnemploymentRegion() {
                    Id = Guid.NewGuid(),
                    Province = "AB"
                }
            };

            var pr3 = new PersonResult() {
                Person = p3,
                BaseAmount = 1,
                VariantAmount = 0
            };

            var p4 = new Person() {
                Id = Guid.NewGuid(),
                UnemploymentRegion = new UnemploymentRegion() {
                    Id = Guid.NewGuid(),
                    Province = "AB"
                }
            };

            var pr4 = new PersonResult() {
                Person = p4,
                BaseAmount = 1,
                VariantAmount = 1
            };

            var p5 = new Person() {
                Id = Guid.NewGuid(),
                UnemploymentRegion = new UnemploymentRegion() {
                    Id = Guid.NewGuid(),
                    Province = "BC"
                }
            };

            var pr5 = new PersonResult() {
                Person = p5,
                BaseAmount = 0,
                VariantAmount = 0
            };

            var p6 = new Person() {
                Id = Guid.NewGuid(),
                UnemploymentRegion = new UnemploymentRegion() {
                    Id = Guid.NewGuid(),
                    Province = "BC"
                }
            };

            var pr6 = new PersonResult() {
                Person = p6,
                BaseAmount = 1,
                VariantAmount = 1
            };

            var result = new List<PersonResult>() {
                pr1, pr2, pr3, pr4, pr5, pr6
            };

            return result;
        }
    }
}
