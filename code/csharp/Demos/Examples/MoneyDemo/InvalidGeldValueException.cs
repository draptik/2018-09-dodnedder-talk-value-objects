using System;

namespace Examples.MoneyDemo
{
    public class InvalidGeldValueException : Exception
    {
        public InvalidGeldValueException(string message) : base(message)
        {
        }
    }
}