using System;

namespace pde_poc_sim.Engine.Interfaces
{
    public interface ISimulationRequest<T> where T : ISimulationCaseRequest
    {
        string SimulationName { get; set; }
        T BaseCaseRequest { get; set; }
        T VariantCaseRequest { get; set; }
    }
}