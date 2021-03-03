using System;
using System.Collections.Generic;

namespace pde_poc_sim.Engine
{
    public class SimulationCase
    {
        public Guid Id { get; set; }
        public decimal MaxWeeklyAmount { get; set; }
        public double Percentage { get; set; }
        public int NumWeeks { get; set; }
        public Dictionary<Guid, UnemploymentRegion> RegionDict { get; set; }

        public SimulationCase() {
            Percentage = 0;
            MaxWeeklyAmount = 0;
            NumWeeks = 0;
            RegionDict = new Dictionary<Guid, UnemploymentRegion>();
        }

        public SimulationCase(Storage.EFModels.Case dbModel) {
            Id = dbModel.Id;
            MaxWeeklyAmount = dbModel.MaxWeeklyAmount;
            Percentage = dbModel.Percentage;
            NumWeeks = dbModel.NumWeeks;
            // Region dict saved separately for now...
        }
    }
}