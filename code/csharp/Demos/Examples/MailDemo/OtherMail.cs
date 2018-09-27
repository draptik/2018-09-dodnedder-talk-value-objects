using System;

namespace Examples.MailDemo
{
    // Example using inheritance
    //
    // Drawback: ORM -> inheritance is always difficult
    public class OtherEmail : Email
    {
        public OtherEmail(string mail) : base (mail)
        {
            if (!IsValid(mail))
            {
                throw new InvalidEmailException(mail);
            }
        }

        private bool IsValid(string mail) => mail.EndsWith("Othername.com");
    }
}