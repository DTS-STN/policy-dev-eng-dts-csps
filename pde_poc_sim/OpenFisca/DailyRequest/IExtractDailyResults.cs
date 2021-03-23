namespace pde_poc_sim.OpenFisca
{
    public interface IExtractDailyResults
    {
         decimal Extract(OpenFiscaResource response);
    }
}