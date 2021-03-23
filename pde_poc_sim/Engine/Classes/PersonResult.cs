using pde_poc_sim.Engine.Interfaces;

namespace pde_poc_sim.Engine
{
    public class PersonResult
    {
        public IPerson Person { get; set; }

        public decimal BaseAmount { get; set; }

        public decimal VariantAmount { get; set; }
    }
}