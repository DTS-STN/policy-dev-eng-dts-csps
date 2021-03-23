using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;

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
                WeeklySchedule = new MvoSchedule() {
                    Hours = new List<HourSet>() {
                        new HourSet(8,0,0,false),
                        new HourSet(9,0,0,false),
                        new HourSet(8,2,0,false),
                        new HourSet(2,8,0,false),
                        new HourSet(8,0,8,false),
                        new HourSet(4,4,4,true),
                        new HourSet(0,0,0,false),
                    }
                }
            };
            
        }
    }
}