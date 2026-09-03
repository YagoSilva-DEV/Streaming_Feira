using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Exceptions
{
    internal class LoginInvalidoException : ApplicationException
    {
        public LoginInvalidoException(string message) : base(message)
        {
        }
    }
}
