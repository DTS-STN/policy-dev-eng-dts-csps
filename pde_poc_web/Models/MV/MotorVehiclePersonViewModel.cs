using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_web.Models
{
    public class MotorVehiclePersonViewModel
    {
        public MvoSchedule WeeklySchedule { get; set; }
 
        public MotorVehiclePersonViewModel() {
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
            };
        }
    }
}