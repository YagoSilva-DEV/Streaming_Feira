using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Exceptions
{
    public class InvalidSignUpException : ApplicationException
    {
        public InvalidSignUpException(string message) : base(message)
        {
        }
    }
}
