using System;
using System.Collections.Generic;

namespace pde_poc_sim.Engine
{
    public class Simulation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public SimulationCase BaseCase { get; set; }
        public SimulationCase VariantCase { get; set; }
    }
}