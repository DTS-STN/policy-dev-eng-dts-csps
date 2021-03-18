using System;
using System.Collections.Generic;
using System.Linq;

namespace pde_poc_rule
{
    public class MotorVehiclePerson : IRulePerson
    {
        public Guid Id { get; set; }
        public MvoSchedule WeeklySchedule { get; set; }
    }

    public class MvoSchedule {
        public List<HourSet> Hours { get; set; }
    }

    // Daily
    public class HourSet {
        public double HoursCmvo { get; set; }
        public double HoursHmvo { get; set; }
        public double HoursOther { get; set; }
        public bool IsHoliday { get; set; }

        public HourSet() {
            HoursCmvo = 0;
            HoursHmvo = 0;
            HoursOther = 0;
            IsHoliday = false;
        }
        public HourSet(double cmvo, double hmvo, double other, bool isHoliday) {
            HoursCmvo = cmvo;
            HoursHmvo = hmvo;
            HoursOther = other;
            IsHoliday = isHoliday;
        }
    }
}