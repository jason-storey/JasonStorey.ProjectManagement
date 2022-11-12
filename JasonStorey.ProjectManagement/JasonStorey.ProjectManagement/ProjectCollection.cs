using System.Collections;
using System.Collections.Generic;

namespace JasonStorey.ProjectManagement
{
    public class ProjectCollection : IEnumerable<Project>
    {
        public static ProjectCollection Create(string name = DEFAULT_PROJECT_COLLECTION_NAME) => 
            new ProjectCollection(name);
        
        public void Add(Project project) => _projects.Add(project);

        public string Name { get; set; }

        public void AddRange(IEnumerable<Project> projects) => _projects.AddRange(projects);

        #region plumbing

        public int Count => _projects.Count;

        public ProjectCollection() : this(DEFAULT_PROJECT_COLLECTION_NAME) { }

        public ProjectCollection(string name)
        {
            _projects = new List<Project>();
            Name = name;
        }

        public IEnumerator<Project> GetEnumerator() => _projects.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        readonly List<Project> _projects;

        const string DEFAULT_PROJECT_COLLECTION_NAME = "Project Collection";

        #endregion
    }
}