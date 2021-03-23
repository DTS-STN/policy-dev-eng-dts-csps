using System;
using System.Collections.Generic;
using System.Linq;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public class MaternityBenefitRuleExecutor : IExecuteRules<MaternityBenefitSimulationCase, MaternityBenefitPerson>
    {

        public decimal Execute(MaternityBenefitSimulationCase rule, MaternityBenefitPerson person) {
            // TODO: Not ideal - need a wrapper for the rule to iterate over persons...
            var bestWeeksDict = rule.RegionDict.ToDictionary(x => x.Key, x => x.Value.BestWeeks);
            
            int bestWeeks = bestWeeksDict[person.UnemploymentRegion.Id];
            decimal averageIncome = person.GetAverageIncome(bestWeeks); 

            decimal temp = averageIncome * (decimal)rule.Percentage/100;
            temp = Math.Min(temp, rule.MaxWeeklyAmount);
            decimal amount = temp * rule.NumWeeks;

            return amount;
        }       

    }
}