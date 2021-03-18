using System;
using System.Collections.Generic;

namespace pde_poc_rule
{
    public class RuleExecutor<T> : IExecuteRules<T>
        where T : IRulePerson
    {
        public Dictionary<Guid, decimal> Execute(IRule<T> rule, List<T> persons) {
            var result = new Dictionary<Guid, decimal>();

            foreach (var person in persons) {
                var amount = rule.Calculate(person);
                result.Add(person.Id, amount);
            }
            return result;
        }
    }
}