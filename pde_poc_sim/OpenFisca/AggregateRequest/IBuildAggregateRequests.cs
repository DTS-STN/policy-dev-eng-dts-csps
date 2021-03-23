using pde_poc_sim.Engine;

namespace pde_poc_sim.OpenFisca
{
    public interface IBuildAggregateRequests
    {
        OpenFiscaResource Build(MotorVehicleSimulationCase rule, MotorVehiclePerson person, decimal dailyResult);
    }
}