using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace pde_poc_web.Models
{
    public class MVCaseViewModel
    {
        [Required(ErrorMessage = "Field is required.")]
        [Range(1,100, ErrorMessage = "Value must be between {1} and {2}.")]
        public double StandardCmvoWeekly { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Range(0,2000, ErrorMessage = "Value must be between {1} and {2}.")]
        public double StandardCmvoDaily { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Range(1,100, ErrorMessage = "Value must be between {1} and {2}.")]
        public double StandardOtherWeekly { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Range(0,2000, ErrorMessage = "Value must be between {1} and {2}.")]
        public double StandardOtherDaily { get; set; }  

        [Required(ErrorMessage = "Field is required.")]
        [Range(0,2000, ErrorMessage = "Value must be between {1} and {2}.")]
        public double StandardHighwayWeekly { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Range(1,100, ErrorMessage = "Value must be between {1} and {2}.")]
        public double StandardHighwayReduction { get; set; }  
    }
}