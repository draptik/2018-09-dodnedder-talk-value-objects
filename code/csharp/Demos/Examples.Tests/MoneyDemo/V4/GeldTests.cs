using System;
using Examples.MoneyDemo;
using Examples.MoneyDemo.V4;
using FluentAssertions;
using Xunit;

namespace Examples.Tests.MoneyDemo.V4
{
    public class GeldTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void Ungueltige_Werte_schmeissen_Exception(int wert)
        {
            Action action = () => new Geld(wert, Waehrung.EUR);
            action.Should().Throw<InvalidGeldValueException>();
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 3, 5)]
        [InlineData(3, 4, 7)]
        public void Addition_von_Geldbetraegen_funktioniert(int betrag1, int betrag2, int endBetrag)
        {
            var g1 = new Geld(betrag1, Waehrung.EUR);
            var g2 = new Geld(betrag2, Waehrung.EUR);
            g1.Addiere(g2).Value.Should().Be(endBetrag);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 3, 5)]
        [InlineData(3, 4, 7)]
        public void Addition_von_Geldbetraegen_mit_plus_funktioniert(int betrag1, int betrag2, int endBetrag)
        {
            var g1 = new Geld(betrag1, Waehrung.EUR);
            var g2 = new Geld(betrag2, Waehrung.EUR);
            (g1+g2).Value.Should().Be(endBetrag);
        }

        [Fact]
        public void Addition_von_Geldbetraegen_mit_unterschiedlicher_Waehrung_schmeisst()
        {
            var g1 = new Geld(1, Waehrung.EUR);
            var g2 = new Geld(1, Waehrung.USD);
            Action action = () => g1.Addiere(g2);
            action.Should().Throw<InvalidGeldValueException>()
                .WithMessage("Waehrungen stimmen nicht ueberein");
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(5, 3, 2)]
        [InlineData(7, 4, 3)]
        public void Subtraktion_von_Geldbetraegen_funktioniert(int betrag1, int betrag2, int endBetrag)
        {
            var g1 = new Geld(betrag1, Waehrung.EUR);
            var g2 = new Geld(betrag2, Waehrung.EUR);
            g1.Subtrahiere(g2).Value.Should().Be(endBetrag);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(5, 3, 2)]
        [InlineData(7, 4, 3)]
        public void Subtraktion_von_Geldbetraegen_mit_minus_funktioniert(int betrag1, int betrag2, int endBetrag)
        {
            var g1 = new Geld(betrag1, Waehrung.EUR);
            var g2 = new Geld(betrag2, Waehrung.EUR);
            (g1-g2).Value.Should().Be(endBetrag);
        }

        [Theory]
        [InlineData(2, 10)]
        public void Subtraktion_von_Geldbetraegen_schmeisst_wenn_Ergebnis_kleiner_Null(int betrag1, int betrag2)
        {
            var g1 = new Geld(betrag1, Waehrung.EUR);
            var g2 = new Geld(betrag2, Waehrung.EUR);
            Action action = () => g1.Subtrahiere(g2);
            action.Should().Throw<InvalidGeldValueException>("weil Geld nicht negativ sein kann");
        }

        [Fact]
        public void Subtraktion_von_Geldbetraegen_mit_unterschiedlicher_Waehrung_schmeisst()
        {
            var g1 = new Geld(1, Waehrung.EUR);
            var g2 = new Geld(1, Waehrung.USD);
            Action action = () => g1.Subtrahiere(g2);
            action.Should().Throw<InvalidGeldValueException>()
                .WithMessage("Waehrungen stimmen nicht ueberein");
        }

    }
}