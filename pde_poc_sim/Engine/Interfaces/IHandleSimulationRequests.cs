using System;

namespace pde_poc_sim.Engine.Lib
{
    public interface IHandleSimulationRequests
    {
         Guid Handle(SimulationRequest request);
    }
}