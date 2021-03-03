using System;
using System.Collections.Generic;
using System.Linq;

namespace pde_poc_sim.Storage.Mocks
{
    public class MockCreator
    {
        private readonly ApplicationDbContext _context;

        public MockCreator(ApplicationDbContext context) {
            _context = context;
        }

        public void Generate() {
            GenerateRegions();

            GeneratePersons(100);

            GenerateBaseCase();
        }

        public void TearDown() {
            var allResults = _context.SimulationResults.ToList();
            _context.SimulationResults.RemoveRange(allResults);

            var allSims = _context.Simulations.ToList();
            _context.Simulations.RemoveRange(allSims);

            var allPersons = _context.Persons.ToList();
            _context.Persons.RemoveRange(allPersons);

            var allCases = _context.Cases.ToList();
            _context.Cases.RemoveRange(allCases);

            var allRegions = _context.UnemploymentRegions.ToList();
            _context.UnemploymentRegions.RemoveRange(allRegions);

            _context.SaveChanges();
        }

        private void GenerateRegions() {
            var regions = UnemploymentRegion.Seed;
            foreach (var region in regions) {
                _context.UnemploymentRegions.Add(region);
            }
            _context.SaveChanges();
        }

        private void GeneratePersons(int amount) {
            var regions = UnemploymentRegion.Seed;

            var rand = new Random();

            for (int i = 0; i < amount; i++) {
                int regionIndex = rand.Next(regions.Count);

                var personId = Guid.NewGuid();
                var age = GenerateAge();

                var nextPerson = new EFModels.Person() {
                    Id = personId,
                    UnemploymentRegionId = regions[regionIndex].Id,
                    UnemploymentRegion = regions[regionIndex],
                    WeeklyIncomes = GenerateWeeklyIncomes(personId, age),
                    Age = age,
                    Flsah = GenerateFslah(),
                };
                _context.Persons.Add(nextPerson);
            }

            _context.SaveChanges();
        }

        private void GenerateBaseCase() {
            var sim = new EFModels.Case() {
                Id = Guid.NewGuid(),
                MaxWeeklyAmount = 595,
                NumWeeks = 15,
                Percentage = 55,
                IsBase = true,
            };

            _context.Cases.Add(sim);
            _context.SaveChanges();
        }

        // Person helpers
        private List<EFModels.WeeklyIncome> GenerateWeeklyIncomes(Guid personId, int age) {
            var result = new List<EFModels.WeeklyIncome>();
            var rand = new Random();

            // pick a base salary, partly based off age
            decimal baseSalary = (rand.Next(15000, 80000) + ((age - 20) * 500)) / 52;
            int diff = Convert.ToInt32(baseSalary * 0.13m);

            for (int i = 0; i < 75; i++) {
                var next = new EFModels.WeeklyIncome() {
                    Id = Guid.NewGuid(),
                    PersonId = personId,
                    StartDate = DateTime.Now.AddDays((58 - i) * -7),
                    Amount = baseSalary + rand.Next(-diff, diff), // Should be informed by data
                };
                result.Add(next);
            }

            return result;
        }
    
        private string GenerateFslah() {
            var result = "Other";
            var rand = new Random();

            var next = rand.Next(7);
            if (next <= 3) {
                result = "English";
            } else if (next <= 5) {
                result = "French";
            }
            return result;
        }

        private int GenerateAge() {
            var rand = new Random();
            return rand.Next(16, 37);
        }
    }
}