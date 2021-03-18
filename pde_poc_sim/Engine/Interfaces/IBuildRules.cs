using pde_poc_rule;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine.Lib
{
    public interface IBuildRules<T, U> 
        where T : ISimulationCase
        where U : pde_poc_rule.IRulePerson
    {
        IRule<U> Build(T simulationCase);
    }
}