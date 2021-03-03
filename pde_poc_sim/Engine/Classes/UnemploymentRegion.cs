using System;

using pde_poc_sim.Storage;

namespace pde_poc_sim.Engine
{
    public class UnemploymentRegion
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public double UnemploymentRate { get; set; }
        public int BestWeeks { get; set; }

        public UnemploymentRegion() {
            Id = new Guid();
            Name = "";
            Province = "";
            UnemploymentRate = 0;
            BestWeeks = 0;
        }

        public UnemploymentRegion(Storage.EFModels.UnemploymentRegion dbModel) {
            Id = dbModel.Id;
            Name = dbModel.Name;
            Province = dbModel.Province;
            UnemploymentRate = dbModel.UnemploymentRate;
            BestWeeks = dbModel.BestWeeks;
        }
    }
}