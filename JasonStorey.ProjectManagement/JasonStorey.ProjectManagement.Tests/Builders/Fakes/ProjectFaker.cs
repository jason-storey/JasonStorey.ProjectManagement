using System.Collections.Generic;
using Bogus;

namespace JasonStorey.ProjectManagement.Tests
{
    public class ProjectFaker
    {
        Faker<Project> _faker;
        public ProjectFaker()
        {
            _faker = new Faker<Project>();
            _faker.RuleFor(x => x.Name, x => x.Commerce.Department());
            _faker.RuleFor(x => x.Description, x => x.Commerce.ProductDescription());
        }
        public Project Build() => _faker.Generate();

        public static implicit operator Project(ProjectFaker faker) => faker.Build();

        public IEnumerable<Project> Generator => _faker.GenerateForever();
    }
}