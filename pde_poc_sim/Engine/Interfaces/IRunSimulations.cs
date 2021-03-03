using System.Collections.Generic;

namespace pde_poc_sim.Engine.Lib
{
    public interface IRunSimulations
    {
         SimulationResult Run(Simulation simulation, List<Person> persons);
    }
}