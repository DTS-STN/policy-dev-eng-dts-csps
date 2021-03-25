using System;
using System.Collections.Generic;
using Xunit;

using pde_poc_sim.Engine;
using pde_poc_sim.OpenFisca;

using OF = pde_poc_sim.OpenFisca.OpenFiscaVariables;

namespace pde_poc.Tests
{
    public class AggregateRequestBuilderTests
    {
        
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            string personName = "person1";
            var simulationCase = BuildSimulationCase();
            var person = BuildPerson();
            decimal dailyResult = 10m;

            // // Act
            var sut = new AggregateRequestBuilder();
            
            var result = sut.Build(simulationCase, person, dailyResult);

            // Assert
            Assert.Single(result.persons.Keys);
            Assert.Null(result.GetProp(personName, OF.TotalOTHours));
            Assert.Equal(1, result.GetProp(personName, OF.NumHolidaysInPeriod));
            Assert.Equal(0, result.GetProp(personName, OF.WeeklyBusHours));
            Assert.Equal(7d, result.GetProp(personName, OF.WeeklyCmvoHours));
            Assert.Equal(13d, result.GetProp(personName, OF.WeeklyHmvoHours));
            Assert.Equal(16d, result.GetProp(personName, OF.WeeklyOtherHours));

            Assert.Equal(8d, result.GetProp(personName, OF.StandardClcDailyHours));
            Assert.Equal(40d, result.GetProp(personName, OF.StandardClcWeeklyHours));
            Assert.Equal(9d, result.GetProp(personName, OF.StandardCmvoDailyHours));
            Assert.Equal(45d, result.GetProp(personName, OF.StandardCmvoWeeklyHours));
            Assert.Equal(10d, result.GetProp(personName, OF.StandardHmvoHolidayReduction));
            Assert.Equal(60d, result.GetProp(personName, OF.StandardHmvoWeeklyHours));

            Assert.Equal(10m, result.GetProp(personName, OF.DailyOTHours));
        }

        private MotorVehicleSimulationCase BuildSimulationCase() {
            return new MotorVehicleSimulationCase() {
                StandardCmvoDaily = 9,
                StandardCmvoWeekly = 45,
                StandardOtherDaily = 8,
                StandardOtherWeekly = 40,
                StandardHighwayWeekly = 60,
                StandardHighwayReduction = 10,                
            };
        }

        private MotorVehiclePerson BuildPerson() {
            return new MotorVehiclePerson() {
                WeeklySchedule = new MvoSchedule() {
                    Hours = new List<HourSet>() {
                        new HourSet() {
                            HoursCmvo = 1,
                            HoursHmvo = 2,
                            HoursOther = 3,
                            IsHoliday = false
                        },
                        new HourSet() {
                            HoursCmvo = 6,
                            HoursHmvo = 7,
                            HoursOther = 8,
                            IsHoliday = false
                        },
                        new HourSet() {
                            HoursCmvo = 1,
                            HoursHmvo = 1,
                            HoursOther = 1,
                            IsHoliday = true
                        },
                        new HourSet() {
                            HoursCmvo = 0,
                            HoursHmvo = 4,
                            HoursOther = 5,
                            IsHoliday = false
                        }
                    }
                }
            };
        }
    }
}
