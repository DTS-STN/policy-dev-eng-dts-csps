using System;
using System.Collections.Generic;
using System.Linq;

namespace pde_poc_rule
{
    public interface IRule<T> where T : IRulePerson
    {
        decimal Calculate(T person);
    }
}