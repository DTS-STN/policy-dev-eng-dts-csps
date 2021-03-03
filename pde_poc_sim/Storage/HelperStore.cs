using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using pde_poc_sim.Storage;
using pde_poc_sim.Engine;


namespace pde_poc_sim.Storage
{
    public class HelperStore :  IHelperStore
    {
        private readonly ApplicationDbContext _context;

        public HelperStore(ApplicationDbContext context) {
            _context = context;
        }

        public List<Person> GetAllPersons() {
            var personsDb = _context.Persons
                .AsNoTracking()
                .Include(x => x.WeeklyIncomes)
                .Include(x => x.UnemploymentRegion)
                .ToList();

            return personsDb.Select(x => new Person(x)).ToList();
        }

        public SimulationCase GetBaseCase() {
            // Will need to add a CreateDate on the SimCase
            var dbModel = _context.Cases
                .AsNoTracking()
                .First(x => x.IsBase == true);
            return new SimulationCase(dbModel);
        }

        public Dictionary<Guid, UnemploymentRegion> GetBestWeeksDict() {
            var dbRes = _context.UnemploymentRegions
                .AsNoTracking()
                .ToList();
            return dbRes.ToDictionary(x => x.Id, x => new UnemploymentRegion(x));
        }
        
    }
}

