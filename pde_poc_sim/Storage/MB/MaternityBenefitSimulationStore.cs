using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Storage
{
    public class MaternityBenefitSimulationStore : IStoreSimulations<MaternityBenefitSimulationCase>
    {
        private readonly ApplicationDbContext _context;

        public MaternityBenefitSimulationStore(ApplicationDbContext context) {
            _context = context;
        }

        public void SaveSimulation(Simulation<MaternityBenefitSimulationCase> simulation) {

            // Save the base case
            var baseCaseId = Guid.NewGuid();
            var baseCase = new EFModels.Case() {
                Id = baseCaseId,
                MaxWeeklyAmount = simulation.BaseCase.MaxWeeklyAmount,
                NumWeeks = simulation.BaseCase.NumWeeks,
                IsBase = true,
                Percentage = simulation.BaseCase.Percentage,
            };
            _context.Cases.Add(baseCase);
            
            // Save the variant case
            var variantCaseId = Guid.NewGuid();
            var variantCase = new EFModels.Case() {
                Id = variantCaseId,
                MaxWeeklyAmount = simulation.VariantCase.MaxWeeklyAmount,
                NumWeeks = simulation.VariantCase.NumWeeks,
                IsBase = false,
                Percentage = simulation.VariantCase.Percentage,
            };
            _context.Cases.Add(variantCase);

            // Save the sim
            var savedSim = new EFModels.Simulation() {
                Id = simulation.Id,
                Name = simulation.Name,
                BaseCaseId = baseCaseId,
                VariantCaseId = variantCaseId,
                Status = 0,
                CreateDate = simulation.DateCreated,
            };
            _context.Simulations.Add(savedSim);
            
            _context.SaveChanges();
        }

        public void StoreResults(Guid simulationId, SimulationResult simulationResult) {
            var resultId = Guid.NewGuid();

            var simResult = new EFModels.SimulationResult() {
                Id = resultId,
                SimulationId = simulationId
            };
            _context.SimulationResults.Add(simResult);

            // Need to update the sim itself
            var sim = _context.Simulations
                .First(x => x.Id == simulationId);

            //sim.SimulationResultId = resultId;
            sim.Status = 1;
            _context.Simulations.Update(sim); 

            var personResultsDb = simulationResult.PersonResults.Select(x => 
                new EFModels.PersonResult() {
                    Id = Guid.NewGuid(),
                    PersonId = x.Person.Id,
                    SimulationResultId = resultId,
                    BaseAmount = x.BaseAmount,
                    VariantAmount = x.VariantAmount,
                }
            );

            foreach (var pr in personResultsDb) {
                _context.PersonResults.Add(pr);
            }

            _context.SaveChanges();
        } 
           
        public Simulation<MaternityBenefitSimulationCase> GetSimulation(Guid id) {
            var dbRes = _context.Simulations
                .AsNoTracking()
                .Include(x => x.BaseCase)
                .Include(x => x.VariantCase)    
                .First(x => x.Id == id);

            var result = ConvertFromDb(dbRes);
            return result; 
        }

        public SimulationResult GetSimulationResult(Guid simulationId) {
            var dbRes = _context.SimulationResults
                .AsNoTracking()
                .Include(y => y.PersonResults)
                    .ThenInclude(z => z.Person)
                        .ThenInclude(w => w.UnemploymentRegion)
                .Include(y => y.PersonResults)
                    .ThenInclude(z => z.Person)
                        .ThenInclude(w => w.WeeklyIncomes)        
                .First(x => x.SimulationId == simulationId);

            var result = ConvertFromDb(dbRes);
            return result;
        }

        public IEnumerable<SimulationLite> GetAll() {
            return _context.Simulations
                .AsNoTracking()
                .Select(x => new SimulationLite() {
                    Id = x.Id,
                    Name = x.Name,
                    DateCreated = x.CreateDate,
                });
        }

        public void Delete(Guid id) {
            var resultToRemove = _context.Simulations.First(x => x.Id == id);
            _context.Simulations.Remove(resultToRemove);
            _context.SaveChanges();
        }

        private Simulation<MaternityBenefitSimulationCase> ConvertFromDb(EFModels.Simulation dbRes) {
            return new Simulation<MaternityBenefitSimulationCase>() {
                Id = dbRes.Id,
                Name = dbRes.Name,
                BaseCase = new MaternityBenefitSimulationCase(dbRes.BaseCase),
                VariantCase = new MaternityBenefitSimulationCase(dbRes.VariantCase),
                DateCreated = dbRes.CreateDate
            };
        }

        private SimulationResult ConvertFromDb(EFModels.SimulationResult dbRes) {
            return new SimulationResult() {
                PersonResults = dbRes.PersonResults.Select(x => 
                    new PersonResult() {
                        Person = new MaternityBenefitPerson(x.Person),
                        BaseAmount = x.BaseAmount,
                        VariantAmount = x.VariantAmount,
                        
                    }
                ).ToList()
            };
        }
    }
}

