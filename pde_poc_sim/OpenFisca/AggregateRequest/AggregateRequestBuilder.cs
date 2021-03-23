using System.Collections.Generic;
using pde_poc_sim.Engine;

using OF = pde_poc_sim.OpenFisca.OpenFiscaVariables;

namespace pde_poc_sim.OpenFisca
{
    public class AggregateRequestBuilder : IBuildAggregateRequests
    {
        public OpenFiscaResource Build(MotorVehicleSimulationCase rule, MotorVehiclePerson person, decimal dailyResult) {
            var result = new OpenFiscaResource();
            string personName = "person1";
            result.CreatePerson(personName);

            // Target value 
            result.SetProp(personName, OF.TotalOTHours, null);

            // Person vars
            result.SetProp(personName, OF.WeeklyHmvoHours, person.WeeklyHmvoHours);
            result.SetProp(personName, OF.WeeklyBusHours, 0);
            result.SetProp(personName, OF.WeeklyCmvoHours, person.WeeklyCmvoHours);
            result.SetProp(personName, OF.WeeklyOtherHours, person.WeeklyOtherHours);
            result.SetProp(personName, OF.NumHolidaysInPeriod, person.NumHolidays);

            // Parameter overrides
            result.SetProp(personName, OF.StandardClcDailyHours, rule.StandardOtherDaily);
            result.SetProp(personName, OF.StandardCmvoDailyHours, rule.StandardCmvoDaily);
            result.SetProp(personName, OF.StandardClcWeeklyHours, rule.StandardOtherWeekly);
            result.SetProp(personName, OF.StandardCmvoWeeklyHours, rule.StandardCmvoWeekly);
            result.SetProp(personName, OF.StandardHmvoHolidayReduction, rule.StandardHighwayReduction);
            result.SetProp(personName, OF.StandardHmvoWeeklyHours, rule.StandardHighwayWeekly);

            // Daily result
            result.SetProp(personName, OF.DailyOTHours, dailyResult);
            
            return result;
        }
    }
}