using System;
using System.Collections.Generic;

namespace pde_poc_sim.Engine.Interfaces
{
    public interface IExecuteRules<T, U> 
        where T : ISimulationCase
        where U : IPerson
    {
        decimal Execute(T rule, U person);
    }
}