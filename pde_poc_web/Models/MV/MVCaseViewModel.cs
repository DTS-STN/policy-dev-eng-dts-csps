using System;
using System.ComponentModel.DataAnnotations;

namespace pde_poc_web.Models
{
    public class MVCaseViewModel
    {
        [Required(ErrorMessage = "Field is required.")]
        [Range(0,168, ErrorMessage = "Standard CMVO Weekly Hours must be between {1} and {2}.")]
        [Display(Name="Standard CMVO Weekly Hours")]
        public double StandardCmvoWeekly { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Range(0,24, ErrorMessage = "Standard CMVO Daily Hours must be between {1} and {2}.")]
        [Display(Name="Standard CMVO Daily Hours")]
        public double StandardCmvoDaily { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Range(0,168, ErrorMessage = "Standard Other Weekly Hours must be between {1} and {2}.")]
        [Display(Name="Standard Other Weekly Hours")]
        public double StandardOtherWeekly { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Range(0,24, ErrorMessage = "Standard Other Daily Hours must be between {1} and {2}.")]
        [Display(Name="Standard Other Daily Hours")]
        public double StandardOtherDaily { get; set; }  

        [Required(ErrorMessage = "Field is required.")]
        [Range(0,168, ErrorMessage = "Standard Highway Weekly Hours must be between {1} and {2}.")]
        [Display(Name="Standard Highway Weekly Hours")]
        public double StandardHighwayWeekly { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Range(0,24, ErrorMessage = "Standard Highway Reduction Hours must be between {1} and {2}.")]
        [Display(Name="Standard Highway Reduction Hours")]
        public double StandardHighwayReduction { get; set; }  
    }
}