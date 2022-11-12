using System;
using FluentAssertions;
using NUnit.Framework;

namespace JasonStorey.ProjectManagement.Tests
{
    [TestFixture]
    public class ProjectShould
    {
        [Test]
        public void When_creating_then_name_matches()
        {
            var randomName = RandomString;
            var randomDescription = RandomString;
            var project = Project.Create(randomName,randomDescription);
            project.Name.Should().Be(randomName);
            project.Description.Should().Be(randomDescription);
        }

        [Test]
        public void When_changing_name_then_name_changes()
        {
            var project = Project.Create("Project");
            var newName = RandomString;
            project.Name = newName;
            project.Name.Should().Be(newName);
        }
        
        
        [Test]
        public void When_changing_description_then_description_changes()
        {
            var project = Project.Create("Project","Description");
            var newDescription = RandomString;
            project.Description = newDescription;
            project.Description.Should().Be(newDescription);
        }
        

        static string RandomString => Guid.NewGuid().ToString();
    }
}