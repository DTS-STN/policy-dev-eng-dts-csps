using System;
using System.Collections.Generic;
using System.Linq;

namespace pde_poc_rule
{
    public interface IPerson
    {
        Guid Id { get; set; }
        Guid UnemploymentRegionId { get; set; }
        List<WeeklyIncome> WeeklyIncome { get; set; }
        decimal GetAverageIncome(int divisor);
    }
}