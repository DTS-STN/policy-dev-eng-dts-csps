using System;
using System.Collections.Generic;
using Xunit;

using pde_poc_sim.Engine;

namespace pde_poc.Tests
{
    public class MotorVehiclePersonTests
    {
        
        [Fact]
        public void ShouldCalculateWeeklyWithoutHoliday()
        {
            // Arrange
            var schedule = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(1, 2, 3, false),
                    new HourSet(4, 5, 6, false),
                }
            };

            // Act
            var person = new MotorVehiclePerson() {
                WeeklySchedule = schedule
            };

            
            // Assert
            Assert.Equal(5, person. WeeklyCmvoHours);
            Assert.Equal(7, person. WeeklyHmvoHours);
            Assert.Equal(9, person. WeeklyOtherHours);
            Assert.Equal(0, person.NumHolidays);
        }

        [Fact]
        public void ShouldCalculateWeeklyWithHoliday()
        {
            // Arrange
            var schedule = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(1, 2, 3, false),
                    new HourSet(1, 2, 3, true),
                    new HourSet(4, 5, 6, false),
                }
            };

            // Act
            var person = new MotorVehiclePerson() {
                WeeklySchedule = schedule
            };

            
            // Assert
            Assert.Equal(5, person. WeeklyCmvoHours);
            Assert.Equal(7, person. WeeklyHmvoHours);
            Assert.Equal(9, person. WeeklyOtherHours);
            Assert.Equal(1, person.NumHolidays);
        }
    }
}
