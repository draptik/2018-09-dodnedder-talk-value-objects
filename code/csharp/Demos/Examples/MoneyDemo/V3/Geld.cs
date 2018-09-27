using System;

namespace Examples.MoneyDemo.V3
{
    public class Geld
    {
        public int Value { get; }

        public Geld(int betrag)
        {
            if (!IsValid(betrag))
            {
                throw new InvalidGeldValueException(betrag.ToString());
            }
            this.Value = betrag;
        }

        public Geld Addiere(Geld geld)
        {
            return new Geld(this.Value + geld.Value);
        }

        public Geld Subtrahiere(Geld geld)
        {
            if (this.Value - geld.Value < 0)
            {
                throw new InvalidGeldValueException("Wert darf nicht kleiner als Null sein.");
            }

            return new Geld(this.Value - geld.Value);
        }

        private bool IsValid(int betrag) 
            => betrag >= 0;
    }
}