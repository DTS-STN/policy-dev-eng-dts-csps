using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace pde_poc_web.Models
{
    public class CaseViewModel
    {
        [Required(ErrorMessage = "Field is required.")]
        [Range(1,100, ErrorMessage = "Value must be between {1} and {2}.")]
        public double Percentage { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Range(0,2000, ErrorMessage = "Value must be between {1} and {2}.")]
        public decimal MaxWeeklyAmount { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Range(0,52, ErrorMessage = "Value must be between {1} and {2}.")]
        public int NumWeeks { get; set; }        
    }
}