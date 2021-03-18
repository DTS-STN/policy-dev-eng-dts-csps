using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

using pde_poc_sim.Engine;
using pde_poc_sim.Engine.Interfaces;

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
        
        public FormViewModel(ISimulationCase baseCase) {
            var mbCase = (MaternityBenefitSimulationCase)baseCase;
            BaseCase = new CaseViewModel() {
                Percentage = mbCase.Percentage,
                MaxWeeklyAmount = mbCase.MaxWeeklyAmount,
                NumWeeks = mbCase.NumWeeks
            };

            VariantCase = new CaseViewModel() {
                Percentage = mbCase.Percentage,
                MaxWeeklyAmount = mbCase.MaxWeeklyAmount,
                NumWeeks = mbCase.NumWeeks
            };

            SimulationName = $"Simulation_{DateTime.Now.ToString("yyyyMMddHHmm")}";
        }     
    }
}