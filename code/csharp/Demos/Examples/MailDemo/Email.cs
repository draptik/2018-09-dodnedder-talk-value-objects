using System;
using System.Text.RegularExpressions;

namespace Examples.MailDemo
{
    public class Email
    {
        public Email(string s)
        {
            if (!IsValid(s))
            {
                throw new InvalidEmailException(s);
            }

            Value = s;
        }

        public string Value { get; }

        // https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        private bool IsValid(string s)
        {
            try
            {
                return Regex.IsMatch(s,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}