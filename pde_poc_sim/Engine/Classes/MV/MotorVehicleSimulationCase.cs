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
        public double MaxCmvoDistance { get; set; }
    }
}