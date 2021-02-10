using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingCore.Exceptions
{
    public class DependencyException : ApplicationException
    {
        public DependencyException(string message):base(message)
        {

        }
    }
}
