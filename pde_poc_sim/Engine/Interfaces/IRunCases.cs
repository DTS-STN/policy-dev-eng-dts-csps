using System.Collections.Generic;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public interface IRunCases<T,U> 
        where T : ISimulationCase
        where U : IPerson
    {
        SimulationCaseResult Run(T simulationCase, IEnumerable<U> persons);
    }
}