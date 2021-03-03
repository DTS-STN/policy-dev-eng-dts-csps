using System;
using System.Collections.Generic;
using pde_poc_sim.Engine;

namespace pde_poc.Tests.Builders
{
    public static class PersonBuilder
    {
        public static Person Generate(Guid personId) {
            return new Person() {
                Id = personId,
                UnemploymentRegion = GenerateUnemploymentRegion(),
                Age = 20,
                Flsah = "English",
                WeeklyIncome = new List<WeeklyIncome>()
            };
        }

        public static UnemploymentRegion GenerateUnemploymentRegion(string province = "SK") {
            return new UnemploymentRegion() {
                Id = new Guid(),
                Name = "Regina",
                Province = province,
                UnemploymentRate = 13.1,
                BestWeeks = 15,
            };
        }
    }
}