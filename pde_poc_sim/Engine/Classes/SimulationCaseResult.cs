using System;
using System.Collections.Generic;

namespace pde_poc_sim.Engine
{
    public class SimulationCaseResult
    {
        public Dictionary<Guid, PersonCaseResult> ResultSet { get; set; }
        
        public SimulationCaseResult()
        {
            ResultSet = new Dictionary<Guid, PersonCaseResult>();
        }

    }
}