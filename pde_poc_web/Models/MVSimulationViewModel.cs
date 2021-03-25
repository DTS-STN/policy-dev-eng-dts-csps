using System;
using System.Collections.Generic;

namespace pde_poc_web.Models
{
    public class MVSimulationViewModel
    {
        public MVCaseViewModel BaseCase { get; set; }
        public MVCaseViewModel VariantCase { get; set; }
        public MotorVehiclePersonViewModel Person { get; set; }
 
        public MVSimulationViewModel() {
            BaseCase = new MVCaseViewModel() {
                StandardCmvoDaily = 9,
                StandardCmvoWeekly = 45,
                StandardOtherDaily = 8,
                StandardOtherWeekly = 40,
                StandardHighwayWeekly = 60,
                StandardHighwayReduction = 10,
            };

            VariantCase = new MVCaseViewModel() {
                StandardCmvoDaily = 9,
                StandardCmvoWeekly = 45,
                StandardOtherDaily = 8,
                StandardOtherWeekly = 40,
                StandardHighwayWeekly = 60,
                StandardHighwayReduction = 10,
            };

            Person = new MotorVehiclePersonViewModel() {
                Hours = new List<HourSetViewModel>() {
                    new HourSetViewModel(0,0,0,false),
                    new HourSetViewModel(0,0,0,false),
                    new HourSetViewModel(0,0,0,false),
                    new HourSetViewModel(0,0,0,false),
                    new HourSetViewModel(0,0,0,false),
                    new HourSetViewModel(0,0,0,false),
                    new HourSetViewModel(0,0,0,false),
                }
            };
            
        }
    }
}