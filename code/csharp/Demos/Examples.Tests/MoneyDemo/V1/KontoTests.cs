using Examples.MoneyDemo.V1;
using FluentAssertions;
using Xunit;

namespace Examples.Tests.MoneyDemo.V1
{
    public class KontoTests
    {


        [Fact]
        public void DoSomething()
        {
            (1 + 1).Should().Be(2);
        }


        [Theory]
        [InlineData(1, true)]
        [InlineData(10, true)]
        [InlineData(0, false)] // <-- Problem?
        [InlineData(-10, false)] // <-- Problem?
        public void Kontostand_ist_nach_Einzahlung_groesser_als_davor(int geld, bool shouldPass)
        {
            // Arrange
            var sut = new Konto(); // SUT: System Under Test

            // Act
            sut.Einzahlen(geld);
            
            // Assert
            if (shouldPass)
            {
                sut.Kontostand.Should().BeGreaterThan(0);    
            }
            else
            {
                sut.Kontostand.Should().BeLessOrEqualTo(0);
            }

            
        }
    }
}
