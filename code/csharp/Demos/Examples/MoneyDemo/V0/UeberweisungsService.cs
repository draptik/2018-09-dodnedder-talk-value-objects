namespace Examples.MoneyDemo.V0
{
    public class UeberweisungsService
    {
        public Ergebniss Ueberweise(int geld, Konto geber, Konto empfaenger)
        {
            if (geld <= 0)
                return new Ergebniss(false);

            if (geber.IstPleite(geld))
                return new Ergebniss(false);

            geber.Entnimmt(geld);
            empfaenger.Bekommt(geld);

            return new Ergebniss(true);
        }
    }
}
