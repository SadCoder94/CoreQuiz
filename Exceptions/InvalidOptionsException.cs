using System;

namespace Exceptions
{
    public class InvalidOptionsException : Exception
    {
        public InvalidOptionsException()
        {

        }

        public InvalidOptionsException(string message) : base(message)
        {

        }
    }
}
