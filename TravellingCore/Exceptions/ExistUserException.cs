using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Exceptions
{
    public class ExistUserException : ApplicationException
    {
        public ExistUserException(string message):base(message)
        {

        }
    }
}
