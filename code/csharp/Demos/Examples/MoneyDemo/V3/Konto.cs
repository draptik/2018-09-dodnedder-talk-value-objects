namespace Examples.MoneyDemo.V3
{
        public class Konto
    {
        public Geld Kontostand { get; private set; } = new Geld(0);

        public void Einzahlen(Geld geld)
        {
            this.Kontostand = Kontostand.Addiere(geld);
        }

        public Geld Abheben(Geld gewuenschterGeldbetrag)
        {
            this.Kontostand = Kontostand.Subtrahiere(gewuenschterGeldbetrag);
            return gewuenschterGeldbetrag;
        }

        public void Ueberweise(Geld geld, Konto empfaengerKonto)
        {
            this.Kontostand = this.Kontostand.Subtrahiere(geld);
            empfaengerKonto.Einzahlen(geld);
        }
    }
}