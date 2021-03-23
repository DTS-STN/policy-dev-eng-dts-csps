using System;
using System.Collections.Generic;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine
{
    public class MaternityBenefitSimulationCaseRequest : ISimulationCaseRequest
    {
        public decimal MaxWeeklyAmount { get; set; }
        public double Percentage { get; set; }
        public int NumWeeks { get; set; }

        public MaternityBenefitSimulationCaseRequest() {
            Percentage = 0;
            MaxWeeklyAmount = 0;
            NumWeeks = 0;
        }
    }
}