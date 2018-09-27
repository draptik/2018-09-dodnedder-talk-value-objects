namespace Examples.MoneyDemo.V2
{
    public class Geld
    {
        public int Value { get; }

        public Geld(int betrag)
        {
            if (!IsValid(betrag))
            {
                throw new InvalidGeldValueException("foo " + betrag.ToString());
            }

            Value = betrag;
        }

        private bool IsValid(int betrag) => betrag >= 0;
    }
}