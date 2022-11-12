using FluentAssertions;
using NUnit.Framework;

namespace JasonStorey.ProjectManagement.Tests
{
    [TestFixture]
    public class ValidatorShould
    {
        [TestCaseSource(typeof(ValidHexColors))]
        public void Given_hex_when_valid_return_true(string validHex) => 
            Validators.IsHexColor(validHex).Should().BeTrue($"{validHex} is a valid hex code");

        [TestCaseSource(typeof(InValidHexColors))]
        public void Given_hex_when_invalid_returns_false(string invalidHex) =>
            Validators.IsHexColor(invalidHex).Should().BeFalse($"{invalidHex} is not a valid hex code");
    }
}