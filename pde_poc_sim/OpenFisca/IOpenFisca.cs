namespace pde_poc_sim.OpenFisca
{
    public interface IOpenFisca
    {
        OpenFiscaResponse Calculate(OpenFiscaRequest request);
    }
}