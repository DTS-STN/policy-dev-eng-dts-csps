using System;
using System.Collections.Generic;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine
{
    public class MaternityBenefitSimulationCase : ISimulationCase
    {
        public Guid Id { get; set; }
        public decimal MaxWeeklyAmount { get; set; }
        public double Percentage { get; set; }
        public int NumWeeks { get; set; }
        public Dictionary<Guid, UnemploymentRegion> RegionDict { get; set; }

        public MaternityBenefitSimulationCase() {
            Percentage = 0;
            MaxWeeklyAmount = 0;
            NumWeeks = 0;
            RegionDict = new Dictionary<Guid, UnemploymentRegion>();
        }

        public MaternityBenefitSimulationCase(Storage.EFModels.Case dbModel) {
            Id = dbModel.Id;
            MaxWeeklyAmount = dbModel.MaxWeeklyAmount;
            Percentage = dbModel.Percentage;
            NumWeeks = dbModel.NumWeeks;
            // Region dict saved separately for now...
        }
    }
}