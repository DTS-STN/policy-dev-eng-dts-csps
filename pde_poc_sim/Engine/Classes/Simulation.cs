using System;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine
{
    public class Simulation<T> where T : ISimulationCase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public T BaseCase { get; set; }
        public T VariantCase { get; set; }
    }
}