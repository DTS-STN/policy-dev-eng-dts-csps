using System;
using System.Collections.Generic;

namespace pde_poc_sim.Storage.EFModels
{
    public class Case
    {
        public Guid Id { get; set; }
        public int NumWeeks { get; set; }
        public double Percentage { get; set; }
        public decimal MaxWeeklyAmount { get; set; }
        public bool IsBase { get; set; }
    }
}