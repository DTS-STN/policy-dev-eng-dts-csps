
using System;
using System.Collections.Generic;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Storage
{
    public interface IStorePersons<T> where T : IPerson
    {
        IEnumerable<T> GetAllPersons();
    }
}