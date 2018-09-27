using System.Collections.Generic;

namespace Examples.MoneyDemo.V4
{
    public class Konto : ValueObject<Konto>
    {
        public Geld Kontostand { get; private set; } = new Geld(0, Waehrung.EUR);

        public void Einzahlen(Geld geld)
        {
            this.Kontostand = Kontostand.Addiere(geld);
        }

        public Geld Abheben(Geld gewuenschterGeldbetrag)
        {
            this.Kontostand = Kontostand - gewuenschterGeldbetrag; // operator overloading
            return gewuenschterGeldbetrag;
        }

        public void Ueberweise(Geld geld, Konto empfaengerKonto)
        {
            var abgehobenesGeld = Abheben(geld);
            empfaengerKonto.Einzahlen(abgehobenesGeld);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object> {Kontostand};
        }
    }
}