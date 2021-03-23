namespace pde_poc_sim.OpenFisca
{
    public interface IOpenFisca
    {
        OpenFiscaResource Calculate(OpenFiscaResource request);
    }
}