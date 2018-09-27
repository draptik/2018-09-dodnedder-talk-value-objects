using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Examples.Tests
{
    public class ExperimentingWithCollectionsTests
    {
        [Fact]
        public void Anlegen_von_Messreihe_schlaegt_nicht_fehl()
        {
            var messwerte = new List<Messwert>
            {
                new Messwert(1, "kg")
            };
            Action action = () => new Messreihe(messwerte);
            action.Should().NotThrow<Exception>();
        }

        
        [Fact]
        public void Hinzufuegen_eines_Messwerts_zur_Messreihe_schlaegt_nicht_fehl()
        {
            var messwerte = new List<Messwert>
            {
                new Messwert(1, "kg")
            };
            
            var messreihe = new Messreihe(messwerte);

            var messreihe2 = messreihe.FuegeMesswertHinzu(new Messwert(2, "liter"));
            messreihe2.Messwerte.Count.Should().Be(2);
        }
    }

    public class Messreihe : ValueObject<Messreihe>
    {
        public List<Messwert> Messwerte { get; }

        public Messreihe(List<Messwert> messwerte)
        {
            Messwerte = messwerte;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck() => 
            new List<object>{Messwerte};

        public Messreihe FuegeMesswertHinzu(Messwert messwert)
        {
            return new Messreihe(this.Messwerte.Append(messwert).ToList());
        }
    }

    public class Messwert : ValueObject<Messwert>
    {
        public int Wert { get; }
        public string Einheit { get; }

        public Messwert(int wert, string einheit)
        {
            Wert = wert;
            Einheit = einheit;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>{Wert, Einheit};
        }
    }
}