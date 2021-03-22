using pde_poc_sim.Engine;

namespace pde_poc_sim.OpenFisca.DailyRequest
{
    public interface IBuildDailyRequests
    {
         OpenFiscaRequest Build(MotorVehicleSimulationCase rule, MotorVehiclePerson person);
    }
}