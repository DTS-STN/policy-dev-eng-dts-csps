using System;

namespace pde_poc_sim.OpenFisca
{
    public class OpenFiscaException : Exception
    {
        public OpenFiscaException()
        {
        }

        public OpenFiscaException(string message) : base(message)
        {
        }

        public OpenFiscaException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}