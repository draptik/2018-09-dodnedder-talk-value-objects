using System;
using Examples.MoneyDemo;
using Examples.MoneyDemo.V2;
using FluentAssertions;
using Xunit;

namespace Examples.Tests.MoneyDemo.V2
{
    public class KontoTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void Einzahlung_mit_ungueltigem_Geldwert_schmeisst_Exception(int geld)
        {
            var sut = new Konto();
            Action action = () => sut.Einzahlen(new Geld(geld));
            action.Should().Throw<InvalidGeldValueException>();
        }
    }
}
