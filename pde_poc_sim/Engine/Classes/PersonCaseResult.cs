using System;
using System.Collections.Generic;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine
{
    public class PersonCaseResult
    {
        public IPerson Person { get; set; }

        public decimal Amount { get; set; }

    }
}