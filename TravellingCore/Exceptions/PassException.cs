using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Exceptions
{
    public class PassException : ApplicationException
    {
        public PassException(string message):base(message)
        {

        }
    }
}
