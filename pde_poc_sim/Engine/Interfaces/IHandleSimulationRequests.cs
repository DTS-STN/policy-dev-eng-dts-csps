using System;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public interface IHandleSimulationRequests <T> where T : ISimulationCaseRequest
    {
         Guid Handle(SimulationRequest<T> request);
    }
}