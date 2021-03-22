using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

using pde_poc_sim.Engine;

namespace pde_poc_web.Models
{
    public class MotorVehicleResultsViewModel
    {
        public SimulationFull<MotorVehicleSimulationCase> FullSimulation { get; set; }
        public MotorVehiclePerson Person { get; set; }
 
        public MotorVehicleResultsViewModel(SimulationFull<MotorVehicleSimulationCase> simulation, MotorVehiclePerson person) {
            FullSimulation = simulation;
            Person = person;
        }
    }
}