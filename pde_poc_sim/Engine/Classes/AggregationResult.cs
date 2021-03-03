using System.Collections.Generic;

namespace pde_poc_sim.Engine
{
    public class AggregationResult
    {
        public string Name { get; set; }
        public Dictionary<string, Aggregation> Dict { get; set;}
    }
}