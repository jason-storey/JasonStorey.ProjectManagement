using System;
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

        [Test]
        public void When_adding_a_project_count_increases()
        {
            var project = Project.Create("Project Name","Does stuff");
            var projects = new ProjectCollection { project };

            projects.Count.Should().Be(1);
            projects.Count().Should().Be(1);
        }

        [Test]
        public void When_calling_create_creates_projectCollection() => 
            ProjectCollection.Create("Stuff").Count.Should().Be(0);

        [Test]
        public void When_foreach_iterates_projects()
        {
            var collection = ProjectCollection.Create();
            for (int i = 0; i < 10; i++) 
                collection.Add(A.Project.WithName($"Project {i}"));

            int index = 0;
            foreach (var item in collection) 
                item.Name.Should().Be($"Project {index++}");
        }

        [Test]
        public void When_adding_range_adds_projects()
        {
            var collection = ProjectCollection.Create();
            collection.AddRange(A.Fake.ListOfProjects.Take(15));
            collection.Count.Should().Be(15);
            collection.Count().Should().Be(15);
        }

        [Test]
        public void When_setting_name_in_constructor_sets_project_collection_name()
        {
            var randomName = Guid.NewGuid().ToString();
            var collection = ProjectCollection.Create(randomName);
            collection.Name.Should().Be(randomName);
        }

        [Test]
        public void When_changing_name_should_change_name()
        {
            var collection = ProjectCollection.Create("Some Name");
            var randomName = Guid.NewGuid().ToString();
            collection.Name = randomName;
            collection.Name.Should().Be(randomName);
        }
    
        
        
    }
}