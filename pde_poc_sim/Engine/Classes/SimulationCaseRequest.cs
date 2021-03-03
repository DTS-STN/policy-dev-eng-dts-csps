using System;
using System.Collections.Generic;

namespace pde_poc_sim.Engine
{
    public class SimulationCaseRequest
    {
        public decimal MaxWeeklyAmount { get; set; }
        public double Percentage { get; set; }
        public int NumWeeks { get; set; }

        public SimulationCaseRequest() {
            Percentage = 0;
            MaxWeeklyAmount = 0;
            NumWeeks = 0;
        }
    }
}