using System;
using FluentAssertions;
using NUnit.Framework;
using static JasonStorey.ProjectManagement.Tests.RandomValues;

namespace JasonStorey.ProjectManagement.Tests
{
    [TestFixture]
    public class ProjectShould
    {
        [Test]
        public void When_created_with_no_color_then_is_default_color() => 
            NewProject.Color.Should().Be(Project.DEFAULT_PROJECT_COLOR);

        [Test]
        public void When_creating_then_name_matches()
        {
            var randomName = String();
            var randomDescription = String(); 
            var project = Project.Create(randomName,randomDescription);
            project.Name.Should().Be(randomName);
            project.Description.Should().Be(randomDescription);
        }

        [Test]
        public void When_changing_name_then_name_changes()
        {
            var project = NewProject;
            var newName = String();
            project.Name = newName;
            project.Name.Should().Be(newName);
        }
        
        
        [Test]
        public void When_changing_description_then_description_changes()
        {
            var project = NewProject;
            var newDescription = String();
            project.Description = newDescription;
            project.Description.Should().Be(newDescription);
            }

        [Test]
        public void When_changing_status_then_status_changes()
        {
            var project = NewProject;
            project.Status = "Started";
            project.Status.Should().Be("Started");
        }

        [Test]
        public void When_created_status_should_be_empty() => 
            NewProject.Status.Should().BeEmpty();

        [Test]
        public void When_changing_createdDate_then_createdDate_changes()
        {
            var newDate = DateTimeOffset.Now;
            var p = NewProject;
            p.CreatedDate = newDate;
            p.CreatedDate.Should().Be(newDate);
        }

        [Test]
        public void When_changing_color_then_color_changes()
        {
            var hexColor = "#ff00ff";
            var p = NewProject;
            p.Color = hexColor;
            p.Color.Should().Be(hexColor);
        }

        [Test]
        public void When_created_created_date_is_today()
        {
            var p = NewProject;
            p.CreatedDate.Date.Should().Be(DateTime.Today);
        }

        [TestCaseSource(typeof(InValidHexColors))]
        public void When_invalid_color_throws_exception(string invalidColor)
        {
            if (invalidColor == null) throw new ArgumentNullException(nameof(invalidColor));
            Project p = NewProject;
            Action setColor = () => p.Color =invalidColor;
            setColor.Should().Throw<ProjectException>($"'{invalidColor}' is not a valid hex color");
        }
        
        [TestCaseSource(typeof(ValidHexColors))]
        public void When_valid_color_sets_color(string validColor)
        {
            Project p = NewProject;
            p.Color = validColor;
            p.Color.Should().Be(validColor);
        }

        Project NewProject => Project.Create("My Project");
    }
}