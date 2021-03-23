using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using pde_poc_sim.Storage;
using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;


namespace pde_poc_sim.Storage
{
    public class MotorVehiclePersonStore :  IStorePersons<MotorVehiclePerson>
    {
        private readonly IMemoryCache _cache;

        public MotorVehiclePersonStore(IMemoryCache cache) {
            _cache = cache;
        }

        public IEnumerable<MotorVehiclePerson> GetAllPersons() {
            var person = _cache.Get<MotorVehiclePerson>("MV_PERSON");
            return new List<MotorVehiclePerson>() {
                person
            };
        }

        
    }
}

