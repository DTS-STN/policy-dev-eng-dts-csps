using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using FakeItEasy;

using pde_poc_sim.Engine.Interfaces;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;
using pde_poc.Tests.Builders;

using OF = pde_poc_sim.OpenFisca.OpenFiscaVariables;

using pde_poc_sim.OpenFisca;

namespace pde_poc.Tests
{
    public class DailyRequestBuilderTests
    {
        
        [Fact]
        public void ShouldWorkNormally()
        {
            // Arrange
            var simulationCase = BuildSimulationCase();
            var person = BuildPerson();

            // Act
            var sut = new DailyRequestBuilder();
            var result = sut.Build(simulationCase, person);

            // Assert

            // Day 1
            Assert.Equal(2, result.persons.Keys.Count);
            Assert.Null(result.GetProp("day_1", OF.DailyOTHours));
            Assert.Equal(0, result.GetProp("day_1", OF.DailyBusHours));
            Assert.Equal(1d, result.GetProp("day_1", OF.DailyCmvoHours));
            Assert.Equal(2d, result.GetProp("day_1", OF.DailyHmvoHours));
            Assert.Equal(3d, result.GetProp("day_1", OF.DailyOtherHours));

            Assert.Equal(8d, result.GetProp("day_1", OF.StandardClcDailyHours));
            Assert.Equal(9d, result.GetProp("day_1", OF.StandardCmvoDailyHours));
            
            // Day 2
            Assert.Null(result.GetProp("day_2", OF.DailyOTHours));
            Assert.Equal(0, result.GetProp("day_2", OF.DailyBusHours));
            Assert.Equal(4d, result.GetProp("day_2", OF.DailyCmvoHours));
            Assert.Equal(5d, result.GetProp("day_2", OF.DailyHmvoHours));
            Assert.Equal(6d, result.GetProp("day_2", OF.DailyOtherHours));

            Assert.Equal(8d, result.GetProp("day_2", OF.StandardClcDailyHours));
            Assert.Equal(9d, result.GetProp("day_2", OF.StandardCmvoDailyHours));
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
                            HoursCmvo = 4,
                            HoursHmvo = 5,
                            HoursOther = 6,
                            IsHoliday = false
                        }
                    }
                }
            };
        }

    }
}
