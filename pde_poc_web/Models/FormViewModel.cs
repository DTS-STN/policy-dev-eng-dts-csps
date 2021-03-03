using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

using pde_poc_sim.Engine;

namespace pde_poc_web.Models
{
    public class FormViewModel
    {
        public CaseViewModel BaseCase { get; set; }

        public CaseViewModel VariantCase { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [MinLength(5)]
        [MaxLength(30)]
        public string SimulationName { get; set; }   

        public FormViewModel() {
            BaseCase = null;
            VariantCase = null;
            SimulationName = "";
        }
        
        public FormViewModel(SimulationCase baseCase) {
            BaseCase = new CaseViewModel() {
                Percentage = baseCase.Percentage,
                MaxWeeklyAmount = baseCase.MaxWeeklyAmount,
                NumWeeks = baseCase.NumWeeks
            };

            VariantCase = new CaseViewModel() {
                Percentage = baseCase.Percentage,
                MaxWeeklyAmount = baseCase.MaxWeeklyAmount,
                NumWeeks = baseCase.NumWeeks
            };

            SimulationName = $"Simulation_{DateTime.Now.ToString("yyyyMMddHHmm")}";
        }     
    }
}