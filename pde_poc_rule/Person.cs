using System;
using System.Collections.Generic;
using System.Linq;

namespace pde_poc_rule
{
    public class Person : IPerson
    {
        public Guid Id { get; set; }
        public Guid UnemploymentRegionId { get; set; }
        public List<WeeklyIncome> WeeklyIncome { get; set; }
        
        public decimal GetAverageIncome(int divisor) {
            if (divisor <= 0) {
                throw new Exception("Divisor must be greater than 0");
            }   
            
            var oneYearAgo = DateTime.Now.AddYears(-1);

            var lastYearsIncome = WeeklyIncome.Where(x => x.StartDate > oneYearAgo);
            var averageIncome = lastYearsIncome
                .OrderByDescending(x => x.Income)
                .Take(divisor)
                .Average(x => x.Income);

            return averageIncome;
        }
    }
}