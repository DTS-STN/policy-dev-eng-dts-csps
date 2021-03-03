namespace pde_poc_rule
{
    public interface IMaternityBenefitRule
    {
        decimal Calculate(IPerson person);    
    }
}