using System;

namespace Examples.MailDemo
{
    public class CompanyEmail
    {
        public CompanyEmail(Email mail)
        {
            if (!IsValid(mail))
            {
                throw new InvalidCompanyEmailException(mail.Value);
            }

            Value = mail;
        }

        public Email Value { get; }

        private bool IsValid(Email mail) => mail.Value.EndsWith("companyname.com");
    }
}