using System;
using Examples.MoneyDemo;
using Examples.MoneyDemo.V2;
using FluentAssertions;
using Xunit;

namespace Examples.Tests.MoneyDemo.V2
{
    public class GeldTests
    {
        [Fact]
        public void Geld_schmeisst_wenn_Betrag_zu_gross()
        {
            Action action = () => new Geld(-1);
            
            action.Should().Throw<InvalidGeldValueException>()
                .WithMessage("foo -1");
        }
    }
}