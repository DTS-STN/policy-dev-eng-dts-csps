using pde_poc_sim.Engine;

namespace pde_poc_sim.OpenFisca.AggregateRequest
{
    public interface IBuildAggregateRequests
    {
         OpenFiscaRequest Build(MotorVehicleSimulationCase rule, MotorVehiclePerson person, decimal dailyResult);
    }
}