using System.Collections.Generic;
using System.Linq;

namespace pde_poc_sim.Engine.Lib
{
    public class DemographicsAggregator : IAggregateDemographics
    {
        
        public AggregationResult AggregateRegion(List<PersonResult> personResults) {
            var result = new Dictionary<string, Aggregation>();

            var gainerGroupings = personResults
                .Where(x => x.VariantAmount > x.BaseAmount)
                .GroupBy(x => x.Person.UnemploymentRegion.Province);
            
            var loserGroupings = personResults
                .Where(x => x.VariantAmount < x.BaseAmount)
                .GroupBy(x => x.Person.UnemploymentRegion.Province);

            var neutralGroupings = personResults
                .Where(x => x.VariantAmount == x.BaseAmount)
                .GroupBy(x => x.Person.UnemploymentRegion.Province);

            foreach (var grouping in gainerGroupings) {
                if (result.ContainsKey(grouping.Key)) {
                    result[grouping.Key].Gainers = grouping.Count();
                } else {
                    result[grouping.Key] = new Aggregation() {
                        Gainers = grouping.Count()
                    };
                }
            }

            foreach (var grouping in loserGroupings) {
                if (result.ContainsKey(grouping.Key)) {
                    result[grouping.Key].Losers = grouping.Count();
                } else {
                    result[grouping.Key] = new Aggregation() {
                        Losers = grouping.Count()
                    };
                }
            }

            foreach (var grouping in neutralGroupings) {
                if (result.ContainsKey(grouping.Key)) {
                    result[grouping.Key].Neutral = grouping.Count();
                } else {
                    result[grouping.Key] = new Aggregation() {
                        Neutral = grouping.Count()
                    };
                }
            }

            return new AggregationResult() {
                Name = "Region",
                Dict = result
            };
        }
    }
}