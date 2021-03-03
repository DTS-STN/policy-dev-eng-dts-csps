using System.Collections.Generic;

namespace pde_poc_sim.Engine.Lib
{
    public interface IRunCases
    {
         SimulationCaseResult Run(SimulationCase simulationCase, List<Person> persons);
    }
}