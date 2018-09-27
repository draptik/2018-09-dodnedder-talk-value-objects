namespace Examples.MoneyDemo.V2
{
    public class Konto
    {
        public Geld Kontostand { get; private set; } = new Geld(0);

        public void Einzahlen(Geld geld)
        {
            this.Kontostand = new Geld(this.Kontostand.Value + geld.Value);
        }
    }
}