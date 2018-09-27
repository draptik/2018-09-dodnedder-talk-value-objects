namespace Examples.MoneyDemo.V1
{
    public class Konto
    {
        public int Kontostand { get; private set; } = 0;

        public void Einzahlen(int geld) => Kontostand += geld;
    }
}
