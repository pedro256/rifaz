using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.Exceptions
{

    public class InternalServerException : Exception
    {
        public InternalServerException(string message) : base(message)
        {
        }

        public InternalServerException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
