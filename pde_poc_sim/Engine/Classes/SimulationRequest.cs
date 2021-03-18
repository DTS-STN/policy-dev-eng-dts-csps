using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine
{
    public class SimulationRequest<T> where T : ISimulationCaseRequest
    {
        public string SimulationName { get; set; }
        public T BaseCaseRequest { get; set; }
        public T VariantCaseRequest { get; set; }

    }
}