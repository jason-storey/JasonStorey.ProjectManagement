using System.Collections.Generic;

namespace JasonStorey.ProjectManagement.Tests
{
    public class Fakers
    {
        public Project Project => new ProjectFaker();
        
        public ProjectCollection ProjectCollection => new ProjectCollectionFaker();

        public IEnumerable<Project> ListOfProjects => new ProjectFaker().Generator;
        
        public static Fakers Instance => _instance ?? (_instance = new Fakers());
        static Fakers _instance;

    }
}