using System;
using Examples.MoneyDemo;
using Examples.MoneyDemo.V3;
using FluentAssertions;
using Xunit;

namespace Examples.Tests.MoneyDemo.V3
{
    public class GeldTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void Ungueltige_Werte_schmeissen_Exception(int wert)
        {
            Action action = () => new Geld(wert);
            action.Should().Throw<InvalidGeldValueException>();
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 3, 5)]
        [InlineData(3, 4, 7)]
        public void Addition_von_Geldbetraegen_funktioniert(int betrag1, int betrag2, int endBetrag)
        {
            var g1 = new Geld(betrag1);
            var g2 = new Geld(betrag2);
            g1.Addiere(g2).Value.Should().Be(endBetrag);
        }
        
        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(5, 3, 2)]
        [InlineData(7, 4, 3)]
        public void Subtraktion_von_Geldbetraegen_funktioniert(int betrag1, int betrag2, int endBetrag)
        {
            var g1 = new Geld(betrag1);
            var g2 = new Geld(betrag2);
            g1.Subtrahiere(g2).Value.Should().Be(endBetrag);
        }

        [Fact]
        public void Does_adding_number_larger_than_max_throw()
        {
            //Action action = () => Add(int.MaxValue);
            //action.Should().Throw<Exception>();

            var result = Add(int.MaxValue);
            result.Should().Be(int.MinValue);
        }

        [Fact]
        public void FactMethodName() => 
            Subtract(int.MinValue).Should().Be(int.MaxValue);

        private static int Add(int foo)
        {
            //checked
            //{
                return foo + 1;    
            //}
        }

        private static int Subtract(int i) => i - 1;

        [Theory]
        [InlineData(2, 10)]
        public void Subtraktion_von_Geldbetraegen_schmeisst_wenn_Ergebnis_kleiner_Null(int betrag1, int betrag2)
        {
            var g1 = new Geld(betrag1);
            var g2 = new Geld(betrag2);
            Action action = () => g1.Subtrahiere(g2);
            action.Should().Throw<InvalidGeldValueException>("weil Geld nicht negativ sein kann");
        }
    }
}