namespace pde_poc_sim.Engine
{
    public class SimulationRequest
    {
        public string SimulationName { get; set; }
        public SimulationCaseRequest BaseCaseRequest { get; set; }
        public SimulationCaseRequest VariantCaseRequest { get; set; }

    }
}