using System;
using System.Linq;
using Examples.DateRangeDemo.V1;
using FluentAssertions;
using Xunit;

namespace Examples.Tests.DateRangeDemo.V1
{
    public class TodoRepositoryTests
    {
        [Theory]
        [InlineData(2018, 1, 01, 2018, 04, 01, 3)]
        [InlineData(2018, 1, 10, 2018, 04, 01, 2)]
        [InlineData(2018, 2, 10, 2018, 04, 01, 1)]
        public void Returns_correct_result(
            int fromYear, int fromMonth, int fromDay,
            int toYear,   int toMonth,   int toDay, 
            int expectedNumberOfResults)
        {
            var from = new DateTime(fromYear, fromMonth, fromDay);
            var to   = new DateTime(toYear,   toMonth,   toDay);

            var sut = new TodoRepository(); // <--- testing complex object :-(

            sut.GetTodosBetween(from, to)
                .Count()
                .Should().Be(expectedNumberOfResults);
        }
    }
}