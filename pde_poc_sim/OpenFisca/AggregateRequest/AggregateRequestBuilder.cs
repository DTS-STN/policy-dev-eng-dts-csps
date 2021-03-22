using System.Collections.Generic;
using pde_poc_sim.OpenFisca;
using pde_poc_sim.Engine;

namespace pde_poc_sim.OpenFisca.AggregateRequest
{
    public class AggregateRequestBuilder : IBuildAggregateRequests
    {
        public OpenFiscaRequest Build(MotorVehicleSimulationCase rule, MotorVehiclePerson person, decimal dailyResult) {
            var result = new OpenFiscaRequest() {
                persons = new Dictionary<string, Dictionary<string, Dictionary<string, object>>>()
            };
            
            result.persons = new Dictionary<string, Dictionary<string, Dictionary<string, object>>>() {
                {
                    "person1", 
                    new Dictionary<string, Dictionary<string,object>>() {
                        {
                            "calculate_overtime_weekly__overtime_worked_hours", 
                            GetDict(null)
                        },
                        // Can get other results as well...
                        {
                            "weekly_work_schedule__total_hours_highway_operator", 
                            GetDict(person.WeeklyHmvoHours)
                        },
                        {
                            "weekly_work_schedule__total_hours_bus_operator", 
                            GetDict(0)
                        },
                        {
                            "weekly_work_schedule__total_hours_city_operator", 
                            GetDict(person.WeeklyCmvoHours)
                        },
                        {
                            "weekly_work_schedule__total_hours_other", 
                            GetDict(person.WeeklyOtherHours)
                        },
                        {
                            "weekly_work_schedule__total_holiday_days_in_period", 
                            GetDict(person.NumHolidays)
                        },
                        // Need daily

                        // Need params

                    }
                }
            };

            return result;
        }

        private Dictionary<string, object> GetDict(object val) {
            return new Dictionary<string, object>() {
                { "2020-09-25", val }
            };
        }
    }

    
}