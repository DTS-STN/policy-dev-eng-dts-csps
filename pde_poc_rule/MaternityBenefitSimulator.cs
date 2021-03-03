using System;
using System.Collections.Generic;

namespace pde_poc_rule
{
    public class MaternityBenefitSimulator : ISimulateMaternityBenefits
    {
        public Dictionary<Guid, decimal> Simulate(IMaternityBenefitRule rule, List<Person> persons) {
            var result = new Dictionary<Guid, decimal>();

            foreach (var person in persons) {
                var amount = rule.Calculate(person);
                result.Add(person.Id, amount);
            }
            return result;
        }
    }
}