
using System;
using System.Collections.Generic;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Storage
{
    public interface IHelperStore<T>
        where T : ISimulationCase
    {
        T GetBaseCase();

        // Pull this out
        Dictionary<Guid, UnemploymentRegion> GetBestWeeksDict();
    }
}