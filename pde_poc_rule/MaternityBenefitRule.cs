using System;
using System.Collections.Generic;

namespace pde_poc_rule
{
    public class MaternityBenefitRule : IMaternityBenefitRule
    {
        private readonly double _percentage;
        private readonly int _numWeeks;
        private readonly decimal _maxWeeklyAmount;
        private readonly Dictionary<Guid, int> _bestWeeksDict;

        public MaternityBenefitRule(
            double percentage,
            int numWeeks,
            decimal maxWeeklyAmount,
            Dictionary<Guid, int> bestWeeksDict
        ) {
            _percentage = percentage;
            _numWeeks = numWeeks;
            _maxWeeklyAmount = maxWeeklyAmount;
            _bestWeeksDict = bestWeeksDict;
        }

        public decimal Calculate(IPerson person) {
            int bestWeeks = _bestWeeksDict[person.UnemploymentRegionId];
            decimal averageIncome = person.GetAverageIncome(bestWeeks); 

            decimal temp = averageIncome * (decimal)_percentage/100;
            temp = Math.Min(temp, _maxWeeklyAmount);
            decimal amount = temp * _numWeeks;

            return amount;
        }        
    }
}