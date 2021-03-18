using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Storage
{
    public class MotorVehicleSimulationStore : IStoreSimulations<MotorVehicleSimulationCase>
    {
        private readonly IMemoryCache _cache;

        public MotorVehicleSimulationStore(IMemoryCache cache) {
            _cache = cache;
        }

        public void SaveSimulation(Simulation<MotorVehicleSimulationCase> simulation) {
            _cache.Set<Simulation<MotorVehicleSimulationCase>>("MV_SIM", simulation);
            
        }

        public void StoreResults(Guid simulationId, SimulationResult simulationResult) {
            _cache.Set<SimulationResult>($"MV_SIM_RESULT_{simulationId}", simulationResult);
        } 
           
        public Simulation<MotorVehicleSimulationCase> GetSimulation(Guid id) {
            return _cache.Get<Simulation<MotorVehicleSimulationCase>>("MV_SIM");
        }

        public SimulationResult GetSimulationResult(Guid simulationId) {
            return _cache.Get<SimulationResult>($"MV_SIM_RESULT_{simulationId}");
        }

        public IEnumerable<SimulationLite> GetAll() {
            return new List<SimulationLite>();
        }

        public void Delete(Guid id) {
            _cache.Remove($"MV_SIM");
            _cache.Remove($"MV_SIM_RESULT_{id}");
        }
    }
}

