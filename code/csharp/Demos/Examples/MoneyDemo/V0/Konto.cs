namespace Examples.MoneyDemo.V0
{
    public class Konto
    {
        public int Geld { get; private set; }

        public void Bekommt(int geld) => Geld += geld;

        public void Entnimmt(int geld) => Geld -= geld;

        public bool IstPleite(int geld) => geld < Geld;
    }
}
