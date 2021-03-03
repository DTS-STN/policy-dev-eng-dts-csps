using System;
using System.Collections.Generic;
using System.Linq;

namespace pde_poc_sim.Engine
{
    public class SimulationResult
    {
        public List<PersonResult> PersonResults { get; set; }


        public SimulationResult() {
            PersonResults = new List<PersonResult>();
        }

        public int TotalGainers {   
            get {
                return PersonResults.Count(x => x.VariantAmount > x.BaseAmount);
            }
        }

        public int TotalLosers {
            get {
                return PersonResults.Count(x => x.VariantAmount < x.BaseAmount);
            }
        }
        public int TotalNeutral {
            get {
                return PersonResults.Count(x => x.VariantAmount == x.BaseAmount);
            }
        }

        public decimal TotalGained { 
            get {
                return PersonResults
                    .Where(x => x.VariantAmount > x.BaseAmount)
                    .Sum(x => x.VariantAmount - x.BaseAmount);
            }

        }

        public decimal TotalLost {
            get {
                return PersonResults
                    .Where(x => x.VariantAmount < x.BaseAmount)
                    .Sum(x => x.VariantAmount - x.BaseAmount);
            }
        }


    }
}