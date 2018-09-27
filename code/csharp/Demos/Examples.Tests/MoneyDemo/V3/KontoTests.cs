using System;
using Examples.MoneyDemo;
using Examples.MoneyDemo.V3;
using FluentAssertions;
using Xunit;

namespace Examples.Tests.MoneyDemo.V3
{
    public class KontoTests
    {
        
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void Konto_hat_nach_initialem_Einzahlung_korrekten_Kontostand(int wert, int expected)
        {
            var sut = new Konto();
            sut.Einzahlen(new Geld(wert));
            sut.Kontostand.Value.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 2, 3, 6)]
        [InlineData(2, 2, 2, 6)]
        public void Konto_hat_nach_mehrmaliger_Einzahlung_korrekten_Kontostand(
            int wert1, int wert2, int wert3, int expected)
        {
            var sut = new Konto();
            sut.Einzahlen(new Geld(wert1));
            sut.Einzahlen(new Geld(wert2));
            sut.Einzahlen(new Geld(wert3));
            sut.Kontostand.Value.Should().Be(expected);
        }

        [Fact]
        public void Konto_gibt_nach_Abheben_korrekten_Wert_zurueck()
        {
            var sut = new Konto();
            sut.Einzahlen(new Geld(10));
            var abhebung = sut.Abheben(new Geld(7));
            abhebung.Value.Should().Be(7);
        }
        
        [Fact]
        public void Konto_hat_nach_Abheben_korrekten_Kontostand()
        {
            var sut = new Konto();
            sut.Einzahlen(new Geld(10));
            sut.Abheben(new Geld(7));
            sut.Kontostand.Value.Should().Be(3);
        }

        [Fact]
        public void Kontostaende_sind_nach_Ueberweisung_korrekt()
        {
            var konto1 = new Konto();
            konto1.Einzahlen(new Geld(10));
            var konto2 = new Konto();
            konto2.Einzahlen(new Geld(100));

            konto1.Ueberweise(new Geld(7), konto2);
            
            konto1.Kontostand.Value.Should().Be(3);
            konto2.Kontostand.Value.Should().Be(107);
        }
    }
}