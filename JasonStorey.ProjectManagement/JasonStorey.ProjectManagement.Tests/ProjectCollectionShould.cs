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
        public void When_adding_a_project_returns_created_project()
        {
            var project = ProjectCollection.Create().Add("My Project");
            project.Name.Should().Be("My Project");
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
            var randomName = RandomString;
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

        [Test]
        public void When_Add_then_adds_new_project()
        {
            var name = RandomString;
            var project = ProjectCollection.Create().Add(name);
            project.Name.Should().Be(name);
        }

        [Test]
        public void When_GetByName_returns_project()
        {
            var project = A.Fake.Project;
            var collection = ProjectCollection.Create();
            collection.Add(project);

            var foundProject = collection.GetByName(project.Name);
            foundProject.Should().Be(project);
        }

        [Test]
        public void Given_validName_When_TryGetByName_returns_true()
        {
            var someName = RandomString;
            
            var collection = ProjectCollection.Create();
            var project = collection.Add(someName);

            var isFound = collection.TryGetByName(someName, out var foundProject);
            isFound.Should().BeTrue();
            foundProject.Should().Be(project);
            foundProject.Name.Should().Be(someName);
        }

        [Test]
        public void Given_invalidName_When_TryGetByName_returns_false()
        {
            var someName = RandomString;
            var someOtherName = RandomString;

            var collection = ProjectCollection.Create();
            collection.Add(someName);

            collection.TryGetByName(someOtherName, out _).Should().BeFalse();
        }

        [Test]
        public void Given_nonExistentProject_when_indexer_throws()
        {
            var collection = ProjectCollection.Create();
            for (int i = 0; i < 10; i++) 
                collection.Add(RandomString);

            Action tryGetByIndexer = () =>
            {
                var result = collection[RandomString];
            };
            
            tryGetByIndexer.Should().Throw<ProjectNotFoundException>();
        }

        [Test]
        public void Given_nonExistentProject_when_ProjectNotFoundThrown_ProjectName_matches_query()
        {
            string NON_EXISTENT_PROJECT_NAME = RandomString;
            try
            {
                var p = ProjectCollection.Create()[NON_EXISTENT_PROJECT_NAME];
            }
            catch (ProjectNotFoundException ex)
            {
                ex.ProjectName.Should().Be(NON_EXISTENT_PROJECT_NAME);
            }
        }
        
        [Test]
        public void Given_existingProject_when_indexer_returns()
        {
            var collection = ProjectCollection.Create();
            var projects = A.Fake.ListOfProjects.Take(5).ToArray();

            collection.AddRange(projects);

            var existing = projects[3];

            collection[existing.Name].Should().Be(existing);

        }

        [Test]
        public void Given_index_when_inRange_returns()
        {
            var collection = ProjectCollection.Create();
            collection.AddRange(A.Fake.ListOfProjects.Take(10));

            collection[0].Should().NotBeNull();
            collection[9].Should().NotBeNull();
        }

        [Test]
        public void Given_index_outOfRange_throws([Values(-1,-12,10,11,200,999)]int invalidIndex)
        {
            var collection = ProjectCollection.Create();
            collection.AddRange(A.Fake.ListOfProjects.Take(10));
            Action tryGetInvalidIndex = () =>
            {
                var result = collection[invalidIndex];
            };
            tryGetInvalidIndex.Should().Throw<IndexOutOfRangeException>($"'{invalidIndex}' out of range 0-10");
        }

        [Test]
        public void Given_index_outOfRange_when_TryGetAtIndex_returnsFalse([Values(-1,-12,10,11,200,999)]int invalidIndex) => 
            ProjectCollection.Create().TryGetAtIndex(invalidIndex, out var project).Should().BeFalse();

        [Test]
        public void Given_index_inRange_when_TryGetAtIndex_returnsTrue()
        {
            var projects = A.Fake.ListOfProjects.Take(20).ToList();
            var collection = ProjectCollection.Create();
            collection.AddRange(projects);

            for (int i = 0; i < 20; i++)
            {
                var found = collection.TryGetAtIndex(i, out var p);
                found.Should().BeTrue();
                p.Should().Be(projects[i]);
            }
        }
        
        [Test]
        public void When_adding_null_project_throws()
        {
            Action tryAddNull = () =>ProjectCollection.Create().Add((Project)null);
            tryAddNull.Should().Throw<ProjectException>("Project cannot be null");
        }

        [Test]
        public void When_add_by_params_returns_results()
        {
            var projects = ProjectCollection.Create().Add("Project A", "Project B", "Project C");
            projects.Length.Should().Be(3);
            projects[0].Name.Should().Be("Project A");
            projects[1].Name.Should().Be("Project B");
            projects[2].Name.Should().Be("Project C");
        }

        [Test]
        public void When_creating_projectcollection_with_objectInitializer_syntax_adds_projects()
        {
            var collection = new ProjectCollection
            {
                { "A", "B", "C", "D" }
            };

            collection.Count.Should().Be(4);
            collection[0].Name.Should().Be("A");
            collection.Last().Name.Should().Be("D");
        }
        
        [Test]
        public void When_valid_search_return_results()
        {
            var collection = ProjectCollection.Create();
            collection.AddRange(A.Fake.ListOfProjects.Take(12));
          //  collection.Add()
            
            
        }
        

        static string RandomString => Guid.NewGuid().ToString();

    }
}