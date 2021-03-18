using System;

namespace pde_poc_sim.Engine.Interfaces
{
    public interface ISimulation<T> where T : ISimulationCase
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime DateCreated { get; set; }
        T BaseCase { get; set; }
        T VariantCase { get; set; }
    }
}