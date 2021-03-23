using System;
using System.Linq;

using OF = pde_poc_sim.OpenFisca.OpenFiscaVariables;

namespace pde_poc_sim.OpenFisca
{
    public class DailyResultExtractor : IExtractDailyResults 
    {
        public decimal Extract(OpenFiscaResource response) {
            decimal totalDailyHours = 0m;
            foreach (var day in response.persons) {
                var dictResult = response.GetProp(day.Key, OF.DailyOTHours);
                var numericValue = Convert.ToDecimal(dictResult);
                totalDailyHours += numericValue;
            }
            return totalDailyHours;
        }
    }
}