namespace pde_poc_sim.Engine.Lib
{
    public interface IBuildSimulations
    {
        Simulation Build(SimulationRequest simulationRequest);
    }
}