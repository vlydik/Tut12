using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tut12.Exceptions
{
    public class NoCustomerException : Exception
    {
        public NoCustomerException(string name) : base(name)
        {}
    }
}
