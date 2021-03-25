using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

using Xunit;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Lib;

using pde_poc_sim.OpenFisca;

using RestSharp;

namespace pde_poc.Tests
{
    public class ExecutorIntegrationTests
    {
        
        [Fact(Skip="Integration test")]
        public void ShouldSucceedInAllScenarios()
        {
            var sut = GetSystem();

            var simulationCase = GetBaseCase();

            var testCases = GetSchedules();

            foreach (var testCase in testCases) {
                var person = new MotorVehiclePerson() {
                    WeeklySchedule = testCase.Item1
                };
                var result = sut.Execute(simulationCase, person);
                Assert.Equal(testCase.Item2, result);
            }
        }

        private MotorVehicleRuleExecutor GetSystem() {
            var restClient = new RestClient();
            var openFiscaOptions = new OpenFiscaOptions() {
                Url = "https://openfiscacanada-dts-csps-main.dev.dts-stn.com"
            };
            var options = Options.Create(openFiscaOptions);

            var openFiscaLib = new OpenFiscaLib(restClient, options);

            var dailyRequestBuilder = new DailyRequestBuilder();
            var dailyResultExtractor = new DailyResultExtractor();
            var aggregateRequestBuilder = new AggregateRequestBuilder();
            var aggregateResultExtractor = new AggregateResultExtractor();
            var executor = new MotorVehicleRuleExecutor(openFiscaLib, dailyRequestBuilder, aggregateRequestBuilder, dailyResultExtractor, aggregateResultExtractor);

            return executor;
        }

        private MotorVehicleSimulationCase GetBaseCase() {
            return new MotorVehicleSimulationCase() {
                StandardCmvoDaily = 9,
                StandardCmvoWeekly = 45,
                StandardOtherDaily = 8,
                StandardOtherWeekly = 40,
                StandardHighwayWeekly = 60,
                StandardHighwayReduction = 10
            };
        }

        private List<Tuple<MvoSchedule,decimal>> GetSchedules() {
            var result = new List<Tuple<MvoSchedule, decimal>>();

            var scenario1 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(0,8,4,false),
                    new HourSet(0,4,8,false),
                    new HourSet(0,10,0,false),
                    new HourSet(0,0,10,false),
                    new HourSet(0,6,6,false),
                    new HourSet(0,0,8,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario1, 4m));

            var scenario2 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(8,0,4,false),
                    new HourSet(4,0,8,false),
                    new HourSet(10,0,0,false),
                    new HourSet(0,0,10,false),
                    new HourSet(6,0,6,false),
                    new HourSet(0,5,0,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario2, 16m));

            var scenario3 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(6,0,6,false),
                    new HourSet(6,0,6,false),
                    new HourSet(10,0,0,false),
                    new HourSet(8,2,0,false),
                    new HourSet(6,0,6,false),
                    new HourSet(0,5,0,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario3, 13m));

            var scenario4 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(9,0,0,false),
                    new HourSet(9,0,0,false),
                    new HourSet(9,0,0,false),
                    new HourSet(9,0,0,false),
                    new HourSet(9,0,0,false),
                    new HourSet(0,0,4,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario4, 4m));

            var scenario6 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(4,4,5,false),
                    new HourSet(4,5,4,false),
                    new HourSet(5,4,4,false),
                    new HourSet(4,4,5,false),
                    new HourSet(4,5,4,false),
                    new HourSet(0,0,0,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario6, 5m));

            var scenario7 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(4,4,6,false),
                    new HourSet(4,6,4,false),
                    new HourSet(6,4,4,false),
                    new HourSet(5,5,5,false),
                    new HourSet(0,0,0,false),
                    new HourSet(0,4,0,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario7, 5m));

            var scenario8 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(8,4,0,false),
                    new HourSet(8,0,4,false),
                    new HourSet(0,2,8,false),
                    new HourSet(0,0,0,true),
                    new HourSet(8,4,0,false),
                    new HourSet(0,6,4,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario8, 6m));

            var scenario9 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(8,4,0,false),
                    new HourSet(8,0,4,false),
                    new HourSet(0,2,8,false),
                    new HourSet(6,5,1,true),
                    new HourSet(8,4,0,false),
                    new HourSet(0,6,4,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario9, 6m));

            var scenario10 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(0,4,10,false),
                    new HourSet(0,12,6,false),
                    new HourSet(13,0,1,false),
                    new HourSet(0,14,0,false),
                    new HourSet(4,0,9,false),
                    new HourSet(0,0,0,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario10, 13m));

            var scenario11 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(0,12,0,false),
                    new HourSet(0,12,0,false),
                    new HourSet(0,12,0,false),
                    new HourSet(0,12,0,false),
                    new HourSet(10,0,2,false),
                    new HourSet(0,0,0,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario11, 3m));

            var scenario12 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(0,0,12,false),
                    new HourSet(0,14,0,false),
                    new HourSet(10,0,0,false),
                    new HourSet(0,6,10,false),
                    new HourSet(0,12,0,false),
                    new HourSet(0,0,6,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario12, 10m));

            var scenario13 = new MvoSchedule() {
                Hours = new List<HourSet>() {
                    new HourSet(8,0,0,false),
                    new HourSet(8,0,0,false),
                    new HourSet(8,0,0,false),
                    new HourSet(0,0,10,false),
                    new HourSet(0,0,0,false),
                    new HourSet(0,10,0,false),
                    new HourSet(0,0,0,false),
                }
            };
            result.Add(new Tuple<MvoSchedule, decimal>(scenario13, 2m));

            return result;
        }
    }


}
