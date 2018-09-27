using System;
using Examples.DateRangeDemo;
using Examples.DateRangeDemo.V2;
using FluentAssertions;
using Xunit;

namespace Examples.Tests.DateRangeDemo.V2
{
    public class ZeitspanneTests
    {
        [Theory]
        [InlineData(2018, 1, 1, 2017, 12, 31)]
        [InlineData(2018, 1, 2, 2017, 12, 31)]
        public void Zeitspanne_schmeisst_wenn_Von_groesser_als_Bis(
            int fromYear,   int fromMonth,   int fromDay,
            int toYear,     int toMonth,     int toDay)
        {
            var von = new DateTime(fromYear,   fromMonth,   fromDay);
            var bis = new DateTime(toYear,     toMonth,     toDay);
            
            Action action = () => new Zeitspanne(von, bis);
            
            action.Should().Throw<InvalidDateRangeException>();
        }

        [Theory]
        [InlineData(2018, 1, 01, 2018, 04, 01, 2018, 1, 01, true)]
        [InlineData(2018, 1, 01, 2018, 04, 01, 2018, 5, 01, false)]
        [InlineData(2018, 1, 01, 2018, 04, 01, 2017, 9, 01, false)]
        public void Returns_correct_results(
            int fromYear,   int fromMonth,   int fromDay,
            int toYear,     int toMonth,     int toDay, 
            int actualYear, int actualMonth, int actualDay, 
            bool expected)
        {
            var von    = new DateTime(fromYear,   fromMonth,   fromDay);
            var bis    = new DateTime(toYear,     toMonth,     toDay);
            var actual = new DateTime(actualYear, actualMonth, actualDay);
            
            var sut = new Zeitspanne(von, bis); // <--- testing Value Object

            sut.Umfasst(actual).Should().Be(expected);
        }

        [Theory]
        [InlineData(2018, 1, 01, 2018, 01, 01)]
        public void Vergleichbarkeit_passt(
            int fromYear,   int fromMonth,   int fromDay,
            int toYear,     int toMonth,     int toDay
            )
        {
            var von    = new DateTime(fromYear,   fromMonth,   fromDay);
            var bis    = new DateTime(toYear,     toMonth,     toDay);
            
            von.Equals(bis).Should().BeTrue();
            (von == bis).Should().BeTrue();
        }
    }
}