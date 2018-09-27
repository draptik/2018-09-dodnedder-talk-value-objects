using System;
using System.Runtime.Serialization;

namespace Examples.DateRangeDemo
{
    public class InvalidDateRangeException : Exception
    {
        public InvalidDateRangeException()
        {
        }

        public InvalidDateRangeException(string message) : base(message)
        {
        }

        public InvalidDateRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDateRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}