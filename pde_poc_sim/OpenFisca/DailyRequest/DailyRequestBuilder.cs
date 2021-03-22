using System.Collections.Generic;
using pde_poc_sim.OpenFisca;
using pde_poc_sim.Engine;


namespace pde_poc_sim.OpenFisca.DailyRequest
{
    public class DailyRequestBuilder : IBuildDailyRequests
    {
        public OpenFiscaRequest Build(MotorVehicleSimulationCase rule, MotorVehiclePerson person) {
            var result = new OpenFiscaRequest() {
                persons = new Dictionary<string, Dictionary<string, Dictionary<string, object>>>()
            };
            

            for (int i = 0; i < person.WeeklySchedule.Hours.Count; i++) {
                var hourSet = person.WeeklySchedule.Hours[i];
                result.persons.Add($"day_{i}", BuildSingleDay(hourSet));
            }
            return result;
        }

        private Dictionary<string, Dictionary<string, object>> BuildSingleDay(HourSet hourSet) {
            // Will need to incorporate the rule in here as well
            // Capture these as constants somewhere
            return new Dictionary<string, Dictionary<string,object>>() {
                        // Target value
                        {
                            "calculate_overtime_daily__overtime_worked_hours", 
                            GetDict(null)
                        },
                        {
                            "daily_work_schedule__total_hours_highway_operator", 
                            GetDict(hourSet.HoursHmvo)
                        },
                        {
                            "daily_work_schedule__total_hours_city_operator", 
                            GetDict(hourSet.HoursCmvo)
                        },
                        {
                            "daily_work_schedule__total_hours_bus_operator", 
                            GetDict(0)
                        },
                        {
                            "daily_work_schedule__total_hours_other", 
                            GetDict(hourSet.HoursOther)
                        },
                        // {
                        //     "standard_hours__daily", 
                        //     GetDict(null)
                        // },
                        // {
                        //     "daily_summed_hours__non_highway_worked_hours", 
                        //     GetDict(null)
                        // }
                    };

        }

        private Dictionary<string, object> GetDict(object val) {
            return new Dictionary<string, object>() {
                { "2020-09-25", val }
            };
        }
    }
}