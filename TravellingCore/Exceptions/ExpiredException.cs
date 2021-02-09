using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Exceptions
{
    public class ExpiredException : ApplicationException
    {
        public ExpiredException(string message):base(message)
        {

        }
    }
}
