using System;
using System.Collections.Generic;

namespace pde_poc_sim.Storage.EFModels
{
    public class WeeklyIncome
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        // public Guid Person { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Amount { get; set; }
        
    }
}