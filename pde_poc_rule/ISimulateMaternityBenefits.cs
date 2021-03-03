using System;
using System.Collections.Generic;

namespace pde_poc_rule
{
    public interface ISimulateMaternityBenefits
    {
        Dictionary<Guid, decimal> Simulate(IMaternityBenefitRule rule, List<Person> persons);
    }
}