using System;
using System.Collections.Generic;

namespace pde_poc_rule
{
    public class MotorVehicleRule : IRule<MotorVehiclePerson>
    {
        public decimal Calculate(MotorVehiclePerson person) {
            // This is the overtime calculation...
            return 0;
        }        
    }
}