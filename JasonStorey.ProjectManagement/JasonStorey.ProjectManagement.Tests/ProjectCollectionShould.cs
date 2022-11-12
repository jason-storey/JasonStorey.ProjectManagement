using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace JasonStorey.ProjectManagement.Tests
{
    [TestFixture]
    public class ProjectCollectionShould
    {
        [Test]
        public void When_Created_HaveNoProjects()
        {
            var projects = new ProjectCollection();
            projects.Count.Should().Be(0);
            projects.Count().Should().Be(0);
        }
    }
}