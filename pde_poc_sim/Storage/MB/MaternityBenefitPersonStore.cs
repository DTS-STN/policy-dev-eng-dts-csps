using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using pde_poc_sim.Storage;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;


namespace pde_poc_sim.Storage
{
    public class MaternityBenefitPersonStore :  IStorePersons<MaternityBenefitPerson>
    {
        private readonly ApplicationDbContext _context;

        public MaternityBenefitPersonStore(ApplicationDbContext context) {
            _context = context;
        }

        public IEnumerable<MaternityBenefitPerson> GetAllPersons() {
            var personsDb = _context.Persons
                .AsNoTracking()
                .Include(x => x.WeeklyIncomes)
                .Include(x => x.UnemploymentRegion);

            return personsDb.Select(x => new MaternityBenefitPerson(x));
        }

        
    }
}

