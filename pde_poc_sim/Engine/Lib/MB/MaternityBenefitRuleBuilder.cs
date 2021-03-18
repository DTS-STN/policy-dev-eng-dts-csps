using System.Linq;

using pde_poc_rule;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public class MaternityBenefitRuleBuilder : IBuildRules<MaternityBenefitSimulationCase, pde_poc_rule.MaternityBenefitPerson>
    {
        public IRule<pde_poc_rule.MaternityBenefitPerson> Build(MaternityBenefitSimulationCase simulationCase) {
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