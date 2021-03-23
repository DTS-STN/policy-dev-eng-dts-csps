namespace pde_poc_sim.OpenFisca
{
    public static class OpenFiscaVariables
    {
        public const string TotalOTHours = "calculate_overtime__overtime_worked_hours";
        
        // Daily
        public const string DailyOTHours = "calculate_overtime_daily__overtime_worked_hours";
        public const string DailyHmvoHours = "daily_work_schedule__total_hours_highway_operator";
        public const string DailyCmvoHours = "daily_work_schedule__total_hours_city_operator";
        public const string DailyBusHours = "daily_work_schedule__total_hours_bus_operator";
        public const string DailyOtherHours = "daily_work_schedule__total_hours_other";


        // Aggregate
        public const string WeeklyOTHours = "calculate_overtime_weekly__overtime_worked_hours";
        public const string WeeklyHmvoHours = "weekly_work_schedule__total_hours_highway_operator";
        public const string WeeklyBusHours = "weekly_work_schedule__total_hours_bus_operator";
        public const string WeeklyCmvoHours = "weekly_work_schedule__total_hours_city_operator";
        public const string WeeklyOtherHours = "weekly_work_schedule__total_hours_other";
        public const string NumHolidaysInPeriod = "weekly_work_schedule__total_holiday_days_in_period";
    
        // Overrides
        public const string StandardClcDailyHours = "daily_clc_standard_hours_of_work";
        public const string StandardClcWeeklyHours = "weekly_clc_standard_hours_of_work";
        public const string StandardCmvoDailyHours = "cmvo_daily_mvo_standard_hours_of_work";
        public const string StandardCmvoWeeklyHours = "cmvo_weekly_mvo_standard_hours_of_work";
        //public const string StandardCmvoHolidayReduction = "cmvo_weekly_holiday_mvo_standard_hours_of_work";
        public const string StandardHmvoHolidayReduction = "hmvo_daily_holiday_reduction_hours";
        public const string StandardHmvoWeeklyHours = "hmvo_weekly_mvo_hours_of_work";


        //public const string StandardOverTimeRate = "overtime_clc_rate";
        //public const string MaxDistanceFromHomeTerminal = "mvo_max_distance_from_home_terminal";
    
    }
}