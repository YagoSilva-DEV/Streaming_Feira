using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Exceptions
{
    internal class DataBaseException : ApplicationException
    {
        public DataBaseException(string message) : base(message) { }
    }
}
