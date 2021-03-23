using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public interface IBuildSimulations<T, U>
        where T : ISimulationCase
        where U : ISimulationCaseRequest
    {
        Simulation<T> Build(SimulationRequest<U> simulationRequest);
    }
}