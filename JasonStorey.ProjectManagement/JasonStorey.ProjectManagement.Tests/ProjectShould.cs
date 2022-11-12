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

        [Test]
        public void When_changing_status_then_status_changes()
        {
            var project = Project.Create("My Project");
            project.Status = "Started";
            project.Status.Should().Be("Started");
        }

        [Test]
        public void When_created_status_should_be_empty() => 
            Project.Create("My Project").Status.Should().BeEmpty();

        [Test]
        public void When_changing_createdDate_then_createdDate_changes()
        {
            var newDate = DateTimeOffset.Now;
            var p = Project.Create("My Project");
            p.CreatedDate = newDate;
            p.CreatedDate.Should().Be(newDate);
        }

        [Test]
        public void When_changing_color_then_color_changes()
        {
            var hexColor = "#ff00ff";
            var p = Project.Create("Some Project");
            p.Color = hexColor;
            p.Color.Should().Be(hexColor);
        }

        [Test]
        public void When_created_created_date_is_today()
        {
            var p = Project.Create("My Project");
            p.CreatedDate.Date.Should().Be(DateTime.Today);
        }

        [TestCaseSource(typeof(InValidHexColors))]
        public void When_invalid_color_throws_exception(string invalidColor)
        {
            if (invalidColor == null) throw new ArgumentNullException(nameof(invalidColor));
            Project p = Project.Create("My Project");
            Action setColor = () => p.Color =invalidColor;
            setColor.Should().Throw<ProjectException>($"'{invalidColor}' is not a valid hex color");
        }
        
        [TestCaseSource(typeof(ValidHexColors))]
        public void When_valid_color_sets_color(string validColor)
        {
            Project p = Project.Create("My Project");
            p.Color = validColor;
            p.Color.Should().Be(validColor);
        }
        
        static string RandomString => Guid.NewGuid().ToString();
    }
}