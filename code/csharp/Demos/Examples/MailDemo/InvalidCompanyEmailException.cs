using System;
using System.Runtime.Serialization;

namespace Examples.MailDemo
{
    [Serializable]
    internal class InvalidCompanyEmailException : Exception
    {
        public InvalidCompanyEmailException()
        {
        }

        public InvalidCompanyEmailException(string message) : base(message)
        {
        }

        public InvalidCompanyEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCompanyEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}