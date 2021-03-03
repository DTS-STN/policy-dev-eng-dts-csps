using System;
using System.Collections.Generic;
using Xunit;

using pde_poc_rule;

namespace pde_poc.Tests
{
    public class PersonTest
    {
        [Fact]
        public void ShouldWorkForMultiple()
        {
            // Arrange
            var weeklyIncomes = new List<WeeklyIncome>();
            for (int i = 0; i < 20; i++) {
                var nextWeeklyIncome = new WeeklyIncome() {
                    Income = 1000,
                    StartDate = DateTime.Now.AddDays(-7 * i)
                };
                weeklyIncomes.Add(nextWeeklyIncome);
            }

            var sut = new Person() {
                WeeklyIncome = weeklyIncomes  
            };

            // Act
            var result = sut.GetAverageIncome(5);

            // Assert
            Assert.Equal(1000, result);
        }

        [Fact]
        public void ShouldWorkForSingle()
        {
            // Arrange
            var weeklyIncome = new WeeklyIncome() {
                Income = 1000,
                StartDate = DateTime.Now.AddDays(-1)
            };

            var sut = new Person() {
                WeeklyIncome = new List<WeeklyIncome>() { weeklyIncome }  
            };

            // Act
            var result = sut.GetAverageIncome(1);

            // Assert
            Assert.Equal(1000, result);
        }

        [Fact]
        public void ShouldFailOnZeroDivisor()
        {
            // Arrange
            var weeklyIncome = new WeeklyIncome() {
                Income = 1000,
                StartDate = DateTime.Now.AddDays(-1)
            };

            var sut = new Person() {
                WeeklyIncome = new List<WeeklyIncome>() { weeklyIncome }  
            };

            // Act/Assert
            Assert.Throws<Exception>(() => sut.GetAverageIncome(0));
        }

        [Fact]
        public void ShouldWorkOnRandomCase()
        {
            // Arrange
            var weeklyIncomes = new List<WeeklyIncome>();
            var rnd = new Random();

            for (int i = 0; i < 75; i++) {
                var weeklyIncome = new WeeklyIncome() {
                    Income = rnd.Next(1000, 2000),
                    StartDate = DateTime.Now.AddDays(-7 * i)
                };
                weeklyIncomes.Add(weeklyIncome);
            }
            

            var sut = new Person() {
                WeeklyIncome = weeklyIncomes
            };

            // Act
            var result = sut.GetAverageIncome(14);

            // Assert
            Assert.True(result < 2000 && result > 1000);
        }

        [Fact]
        public void ShouldWorkOnSpecificCase()
        {
            // Arrange
            var weeklyIncomes = new List<WeeklyIncome>();
            var incomeList = new List<decimal>() { 1000, 1050, 950, 1010, 1049, 1041, 1033, 1044, 1022, 1020, 10, 10 };

            for (int i = 0; i < incomeList.Count; i++) {
                var weeklyIncome = new WeeklyIncome() {
                    Income = incomeList[i],
                    StartDate = DateTime.Now.AddDays(-7 * i)
                };
                weeklyIncomes.Add(weeklyIncome);
            }
            
            var sut = new Person() {
                WeeklyIncome = weeklyIncomes,
            };

            // Act
            var result = sut.GetAverageIncome(10);

            // Assert
            Assert.Equal(1021.9m, result);
        }
    
        
    }
}
