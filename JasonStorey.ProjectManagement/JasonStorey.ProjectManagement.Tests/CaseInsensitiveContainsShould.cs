using FluentAssertions;
using NUnit.Framework;

namespace JasonStorey.ProjectManagement.Tests
{
    [TestFixture]
    public class CaseInsensitiveContainsShould
    {
        [TestCaseSource(typeof(ContainsValidCases))]
        public void Given_valid_cases_should_return_true(string sentence,string search) => 
            CaseInsensitiveContains.Instance.Matches(search, sentence).Should().BeTrue();

        [TestCaseSource(typeof(ContainsInvalidCases))]
        public void Given_invalid_cases_should_return_false(string sentence, string search) =>
            CaseInsensitiveContains.Instance.Matches(search, sentence).Should().BeFalse();
    }
}