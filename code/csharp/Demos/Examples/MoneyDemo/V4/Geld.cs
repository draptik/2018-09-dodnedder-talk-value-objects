using System;
using System.Collections.Generic;
using Examples;


namespace Examples.MoneyDemo.V4
{
    public class Geld : ValueObject<Geld>
    {
        public int Value { get; }

        public Waehrung Waehrung { get; }

        public Geld(int betrag, Waehrung waehrung)
        {
            if (!IsValid(betrag, waehrung))
            {
                throw new InvalidGeldValueException(betrag.ToString());
            }
            this.Value = betrag;
            this.Waehrung = waehrung;
        }

        public Geld Addiere(Geld geld)
        {
            if (this.Waehrung != geld.Waehrung)
            {
                throw new InvalidGeldValueException("Waehrungen stimmen nicht ueberein");
            }

            try
            {
                return new Geld(this.Value + geld.Value, this.Waehrung);
            }
            catch (System.Exception)
            {
                throw new InvalidGeldValueException("Wert ist zu gross (groesser als Int32.MaxValue).");
            }
        }

        public static Geld operator +(Geld g1, Geld g2) => g1.Addiere(g2);

        public Geld Subtrahiere(Geld geld)
        {
            if (this.Waehrung != geld.Waehrung)
            {
                throw new InvalidGeldValueException("Waehrungen stimmen nicht ueberein");
            }

            return new Geld(this.Value - geld.Value, this.Waehrung);
        }

        public static Geld operator -(Geld g1, Geld g2) => g1.Subtrahiere(g2);

        private bool IsValid(int betrag, Waehrung waehrung)
            => betrag >= 0 && waehrung != Waehrung.Undefined;

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object> {Value, Waehrung};
        }
    }

}