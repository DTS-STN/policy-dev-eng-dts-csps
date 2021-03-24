using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;


namespace pde_poc_web.Models
{
    public class MotorVehiclePersonViewModel
    {
        public List<HourSetViewModel> Hours { get; set; }
 
        public MotorVehiclePersonViewModel() {
            Hours = new List<HourSetViewModel>() {
                new HourSetViewModel(8,0,0,false),
                new HourSetViewModel(9,0,0,false),
                new HourSetViewModel(8,2,0,false),
                new HourSetViewModel(2,8,0,false),
                new HourSetViewModel(8,0,8,false),
                new HourSetViewModel(4,4,4,true),
                new HourSetViewModel(0,0,0,false),
            };
        }
    }

    public class HourSetViewModel {
        [Range(0,24, ErrorMessage = "Hours must be between {1} and {2}.")]
        [DefaultValue(0)]
        public double? HoursCmvo { 
            get { 
                return _hoursCmvo; 
            }
            set { 
                _hoursCmvo = value.GetValueOrDefault(0);
            }
        }
        private double _hoursCmvo;

        [Range(0,24, ErrorMessage = "Hours must be between {1} and {2}.")]
        [DefaultValue(0)]
        public double? HoursHmvo { 
            get { 
                return _hoursHmvo; 
            }
            set { 
                _hoursHmvo = value.GetValueOrDefault(0);
            }
        }
        private double _hoursHmvo;

        [Range(0,24, ErrorMessage = "Hours must be between {1} and {2}.")]
        [DefaultValue(0)]
        public double? HoursOther { 
            get { 
                return _hoursOther; 
            }
            set { 
                _hoursOther = value.GetValueOrDefault(0);
            }
        }
        private double _hoursOther;

        public bool IsHoliday { get; set; }

        public HourSetViewModel() {
            HoursCmvo = 0;
            HoursHmvo = 0;
            HoursOther = 0;
            IsHoliday = false;
        }
        public HourSetViewModel(double cmvo, double hmvo, double other, bool isHoliday) {
            HoursCmvo = cmvo;
            HoursHmvo = hmvo;
            HoursOther = other;
            IsHoliday = isHoliday;
        }
    }
}