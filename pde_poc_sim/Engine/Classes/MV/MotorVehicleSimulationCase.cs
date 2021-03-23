using System;
using System.Collections.Generic;

using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine
{
    public class MotorVehicleSimulationCase : ISimulationCase
    {
        public Guid Id { get; set; }
        public double StandardCmvoWeekly { get; set; }
        public double StandardCmvoDaily { get; set; }
        public double StandardOtherWeekly { get; set; }
        public double StandardOtherDaily { get; set; }
        public double StandardHighwayWeekly { get; set; }
        public double StandardHighwayReduction { get; set; }

        public MotorVehicleSimulationCase() {
            Id = Guid.NewGuid();
            StandardCmvoWeekly = 0;
            StandardCmvoDaily = 0;
            StandardHighwayReduction = 0;
            StandardHighwayWeekly = 0;
            StandardOtherDaily = 0;
            StandardOtherWeekly = 0;
        }

        public MotorVehicleSimulationCase(MotorVehicleSimulationCaseRequest request) {
            Id = Guid.NewGuid();
            StandardCmvoWeekly = request.StandardCmvoWeekly;
            StandardCmvoDaily = request.StandardCmvoDaily;
            StandardHighwayReduction = request.StandardHighwayReduction;
            StandardHighwayWeekly = request.StandardHighwayWeekly;
            StandardOtherDaily = request.StandardOtherDaily;
            StandardOtherWeekly = request.StandardOtherWeekly;
        }
    }
}