using System.Collections.Generic;

namespace pde_poc_sim.Engine.Lib
{
    public interface IJoinResults
    {
         List<PersonResult> Join(SimulationCaseResult baseResult, SimulationCaseResult variantResult);
    }
}