using System;
using System.Collections;
using System.Collections.Generic;
using Bogus;

namespace JasonStorey.ProjectManagement.Tests
{
    public class ProjectCollectionFaker
    {
        static Random Random = new Random();
        Faker<Project> _projectFaker;
        Faker<ProjectCollection> _projectCollectionFaker;

        public ProjectCollectionFaker()
        {
            _projectFaker = new Faker<Project>();
            _projectFaker.RuleFor(x => x.Name, x => x.Commerce.Department());
            _projectFaker.RuleFor(x => x.Description, x => x.Commerce.ProductDescription());
            
            _projectCollectionFaker = new Faker<ProjectCollection>();
            _projectCollectionFaker.RuleFor(x => x.Name, x => x.Commerce.Department());
            
            
            
        }
        
        public ProjectCollection Build()
        {
            ProjectCollection collection = _projectCollectionFaker.Generate();
            for (int i = 0; i < Random.Next(5,25); i++) 
                collection.Add(_projectFaker.Generate());
            return collection;
        }

        public static implicit operator ProjectCollection(ProjectCollectionFaker faker) => faker.Build();

       
    }
}