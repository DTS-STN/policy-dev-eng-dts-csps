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
            
            // Do this...

            // vars
            /*
            daily amount
            total weekly cmvo
            total weekly hmvo
            total weekly other
            holiday info
            parameters...
            
            */
            result.persons = new Dictionary<string, Dictionary<string, Dictionary<string, object>>>() {
                {
                    "person1", 
                    new Dictionary<string, Dictionary<string,object>>() {
                        {
                            "mvo__is_cmvo", 
                            GetDict(null)
                        },
                        {
                            "mvo__vehicle_is_operated_by_employee", 
                            GetDict(true)
                        },
                        {
                            "mvo__vehicle_is_designed_for_rails", 
                            GetDict(false)
                        },
                        {
                            "mvo__vehicle_is_powered_by_muscles", 
                            GetDict(false)
                        },
                        {
                            "mvo__operates_a_bus", 
                            GetDict(false)
                        },
                        {
                            "mvo__has_collective_cmvo_agreement", 
                            GetDict(false)
                        },
                        {
                            "mvo__is_cmvo_under_prevailing_industry_practice", 
                            GetDict(false)
                        },
                        {
                            "mvo__distance_from_home_terminal", 
                            GetDict(9.99)
                        }
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