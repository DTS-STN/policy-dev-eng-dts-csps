using System;
using System.Collections.Generic;
using System.Linq;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine
{
    public class MaternityBenefitPerson : IPerson
    {
        public Guid Id { get; set; }
        public UnemploymentRegion UnemploymentRegion { get; set; }
        public int Age { get; set; }
        public string Flsah { get; set; }
        public List<WeeklyIncome> WeeklyIncome { get; set; }

        public MaternityBenefitPerson() {
            Id = new Guid();
            UnemploymentRegion = new UnemploymentRegion();
            Age = 0;
            Flsah = "";
            WeeklyIncome = new List<WeeklyIncome>();
        }
        
        public MaternityBenefitPerson(Storage.EFModels.Person dbModel) {
            Id = dbModel.Id;
            UnemploymentRegion = new UnemploymentRegion(dbModel.UnemploymentRegion);
            Age = dbModel.Age;
            Flsah = dbModel.Flsah;
            WeeklyIncome = dbModel.WeeklyIncomes.Select(x => new WeeklyIncome(x)).ToList();   
        }
    }
}