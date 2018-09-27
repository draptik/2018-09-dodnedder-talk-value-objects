using System;
using Examples.MoneyDemo;
using Examples.MoneyDemo.V4;
using FluentAssertions;
using Xunit;

namespace Examples.Tests.MoneyDemo.V4
{
    public class KontoTests
    {
        
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void Konto_hat_nach_initialem_Einzahlung_korrekten_Kontostand(int wert, int expected)
        {
            var sut = new Konto();
            sut.Einzahlen(new Geld(wert, Waehrung.EUR));
            sut.Kontostand.Value.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 2, 3, 6)]
        [InlineData(2, 2, 2, 6)]
        public void Konto_hat_nach_mehrmaliger_Einzahlung_korrekten_Kontostand(
            int wert1, int wert2, int wert3, int expected)
        {
            var sut = new Konto();
            sut.Einzahlen(new Geld(wert1, Waehrung.EUR));
            sut.Einzahlen(new Geld(wert2, Waehrung.EUR));
            sut.Einzahlen(new Geld(wert3, Waehrung.EUR));
            sut.Kontostand.Value.Should().Be(expected);
        }

        [Fact]
        public void Konto_gibt_nach_Abheben_korrekten_Wert_zurueck()
        {
            var sut = new Konto();
            sut.Einzahlen(new Geld(10, Waehrung.EUR));
            var abhebung = sut.Abheben(new Geld(7, Waehrung.EUR));
            abhebung.Value.Should().Be(7);
        }
        
        [Fact]
        public void Konto_hat_nach_Abheben_korrekten_Kontostand()
        {
            var sut = new Konto();
            sut.Einzahlen(new Geld(10, Waehrung.EUR));
            sut.Abheben(new Geld(7, Waehrung.EUR));
            sut.Kontostand.Value.Should().Be(3);
        }

        [Fact]
        public void Kontostaende_sind_nach_Ueberweisung_korrekt()
        {
            var konto1 = new Konto();
            konto1.Einzahlen(new Geld(10, Waehrung.EUR));
            var konto2 = new Konto();
            konto2.Einzahlen(new Geld(100, Waehrung.EUR));

            konto1.Ueberweise(new Geld(7, Waehrung.EUR), konto2);
            
            konto1.Kontostand.Value.Should().Be(3);
            konto2.Kontostand.Value.Should().Be(107);
        }
    }
}