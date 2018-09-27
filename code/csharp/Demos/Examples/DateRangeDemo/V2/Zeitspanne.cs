using System;
using System.Collections.Generic;

namespace Examples.DateRangeDemo.V2
{
    public class Zeitspanne : ValueObject<Zeitspanne>
    {
        public DateTime Von { get; }
        public DateTime Bis { get; }

        public Zeitspanne(DateTime von, DateTime bis)
        {
            if (!IsValid(von, bis))
            {
                throw new InvalidDateRangeException();
            }
            
            Von = von;
            Bis = bis;
        }

        private bool IsValid(DateTime von, DateTime bis) => von < bis;

        public bool Umfasst(DateTime d) => d >= Von && d <= Bis;

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object> {Von, Bis};
        }
    }
}