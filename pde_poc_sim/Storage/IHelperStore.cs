
using System;
using System.Collections.Generic;

using pde_poc_sim.Engine;

namespace pde_poc_sim.Storage
{
    public interface IHelperStore
    {
        List<Person> GetAllPersons();
        SimulationCase GetBaseCase();
        Dictionary<Guid, UnemploymentRegion> GetBestWeeksDict();
    }
}