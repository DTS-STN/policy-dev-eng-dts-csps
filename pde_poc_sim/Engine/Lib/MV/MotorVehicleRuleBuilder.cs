using System.Linq;

using pde_poc_rule;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public class MotorVehicleRuleBuilder : IBuildRules<MotorVehicleSimulationCase, pde_poc_rule.MotorVehiclePerson>
    {
        public IRule<pde_poc_rule.MotorVehiclePerson> Build(MotorVehicleSimulationCase simulationCase) {

            MotorVehicleRule rule = new MotorVehicleRule();

            return rule;
        }
    }
}