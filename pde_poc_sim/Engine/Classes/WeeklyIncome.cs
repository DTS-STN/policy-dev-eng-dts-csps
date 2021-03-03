using System;

using pde_poc_sim.Storage;

namespace pde_poc_sim.Engine
{
    public class WeeklyIncome
    {
        public DateTime StartDate { get; set; }
        public decimal Income { get; set; }

        public WeeklyIncome(Storage.EFModels.WeeklyIncome dbModel) {
            StartDate = dbModel.StartDate;
            Income = dbModel.Amount;
        }
    }
}