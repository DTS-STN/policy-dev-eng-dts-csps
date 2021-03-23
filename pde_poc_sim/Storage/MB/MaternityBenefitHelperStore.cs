using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using pde_poc_sim.Storage;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;


namespace pde_poc_sim.Storage
{
    // Specific to MB...?
    public class MaternityBenefitHelperStore:  IHelperStore<MaternityBenefitSimulationCase>
    {
        private readonly ApplicationDbContext _context;

        public MaternityBenefitHelperStore(ApplicationDbContext context) {
            _context = context;
        }

        public MaternityBenefitSimulationCase GetBaseCase() {
            // Will need to add a CreateDate on the SimCase
            var dbModel = _context.Cases
                .AsNoTracking()
                .First(x => x.IsBase == true);
            return new MaternityBenefitSimulationCase(dbModel);
        }

        public Dictionary<Guid, UnemploymentRegion> GetBestWeeksDict() {
            var dbRes = _context.UnemploymentRegions
                .AsNoTracking()
                .ToList();
            return dbRes.ToDictionary(x => x.Id, x => new UnemploymentRegion(x));
        }
        
    }
}

