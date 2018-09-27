using System;
using Examples.MailDemo;
using FluentAssertions;
using Xunit;


namespace Examples.Tests.MailDemo
{
    public class EmailTests
    {
        [Theory]
        [InlineData((string)null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("abc")]
        [InlineData("a@a@a")]
        [InlineData("@abc")]
        public void Creating_Email_should_throw_when_given_invalid_input(string invalidInput)
        {
            Action action = () => new Email(invalidInput);
            action.Should().Throw<InvalidEmailException>();
        }

        [Theory]
        [InlineData("foo@bar.de")]
        [InlineData("test.test@test.com")]
        public void Creating_Email_should_not_throw_when_given_valid_input(string validInput)
        {
            Action action = () => new Email(validInput);
            action.Should().NotThrow<InvalidEmailException>();
        }
    }
}