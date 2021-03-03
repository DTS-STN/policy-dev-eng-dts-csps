using System;
using System.Collections.Generic;

namespace pde_poc_sim.Storage.EFModels
{
    public class Person
    {
        public Guid Id { get; set; }
        public Guid UnemploymentRegionId { get; set; }
        public UnemploymentRegion UnemploymentRegion { get; set; }
        public string Flsah { get; set; }
        public int Age { get; set; }
        public List<WeeklyIncome> WeeklyIncomes { get; set; }
    }
}