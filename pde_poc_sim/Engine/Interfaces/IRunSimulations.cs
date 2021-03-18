using System.Collections.Generic;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public interface IRunSimulations<T, U>
        where T : ISimulationCase
        where U : IPerson
    {
         SimulationResult Run(Simulation<T> simulation, IEnumerable<U> persons);
    }
}