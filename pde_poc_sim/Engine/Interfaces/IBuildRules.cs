using pde_poc_rule;

namespace pde_poc_sim.Engine.Lib
{
    public interface IBuildRules
    {
        MaternityBenefitRule Build(SimulationCase simulationCase);
    }
}