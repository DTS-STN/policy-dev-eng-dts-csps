using System.Collections.Generic;
using pde_poc_sim.Engine;

using OF = pde_poc_sim.OpenFisca.OpenFiscaVariables;


namespace pde_poc_sim.OpenFisca
{
    public class DailyRequestBuilder : IBuildDailyRequests
    {
        public OpenFiscaResource Build(MotorVehicleSimulationCase rule, MotorVehiclePerson person) {
            var result = new OpenFiscaResource();
            
            for (int i = 0; i < person.WeeklySchedule.Hours.Count; i++) {
                var hourSet = person.WeeklySchedule.Hours[i];
                var personName = $"day_{i+1}";
                result.CreatePerson(personName);
                result.SetProp(personName, OF.DailyOTHours, null);
                result.SetProp(personName, OF.DailyHmvoHours, hourSet.HoursHmvo);
                result.SetProp(personName, OF.DailyCmvoHours, hourSet.HoursCmvo);
                result.SetProp(personName, OF.DailyBusHours, 0);
                result.SetProp(personName, OF.DailyOtherHours, hourSet.HoursOther);

                result.SetProp(personName, OF.StandardClcDailyHours, rule.StandardOtherDaily);
                result.SetProp(personName, OF.StandardCmvoDailyHours, rule.StandardCmvoDaily);

                // Any need to add holiday hours?
            }
            return result;
        }
    }
}