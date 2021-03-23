namespace pde_poc_sim.OpenFisca
{
    public interface IExtractAggregateResults
    {
         decimal Extract(OpenFiscaResource response);
    }
}