using System.Collections.Generic;

namespace pde_poc_sim.Engine.Lib
{
    public interface IAggregateDemographics
    {
        AggregationResult AggregateRegion(List<PersonResult> personResults);
    }
}