using System;
using System.Collections.Generic;

namespace pde_poc_rule
{
    public interface IExecuteRules<T> where T : IRulePerson
    {
        Dictionary<Guid, decimal> Execute(IRule<T> rule, List<T> persons);
    }
}