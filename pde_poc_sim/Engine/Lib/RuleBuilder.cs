using System.Linq;

using pde_poc_rule;

namespace pde_poc_sim.Engine.Lib
{
    public class RuleBuilder : IBuildRules
    {
        public MaternityBenefitRule Build(SimulationCase simulationCase) {
            var bestWeeksDict = simulationCase.RegionDict.ToDictionary(x => x.Key, x => x.Value.BestWeeks);
        
            MaternityBenefitRule rule = new MaternityBenefitRule(
                simulationCase.Percentage,
                simulationCase.NumWeeks,
                simulationCase.MaxWeeklyAmount,
                bestWeeksDict
            );

            return rule;
        }
    }
}