using System;
using System.Linq;

using OF = pde_poc_sim.OpenFisca.OpenFiscaVariables;

namespace pde_poc_sim.OpenFisca
{
    public class AggregateResultExtractor : IExtractAggregateResults
    {
        public decimal Extract(OpenFiscaResource response) {
            var personKey = response.persons.First().Key;
            var dictResult = response.GetProp(personKey, OF.TotalOTHours);
            return Convert.ToDecimal(dictResult);
        }
    }
}