using System.Collections.Generic;

namespace pde_poc_sim.OpenFisca
{
    public class OpenFiscaResponse {
        public Dictionary<string, Dictionary<string, Dictionary<string, object>>> persons { get; set; }
    }
}