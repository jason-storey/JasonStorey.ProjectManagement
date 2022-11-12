using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JasonStorey.ProjectManagement
{
    public class ProjectCollection : IEnumerable<Project>
    {
        readonly StringSearch _defaultSearch;

        public static ProjectCollection Create(string name = DEFAULT_PROJECT_COLLECTION_NAME, StringSearch search = null) => 
            new ProjectCollection(search,name);

        public Project[] Add(params string[] projectNames)
        {
            Project[] created = new Project[projectNames.Length];
            for (int i = 0; i < projectNames.Length; i++)
            {
                created[i] = Add(projectNames[i]);
            }
            return created;
        }
        
        public void Add(Project project)
        {
            if (project == null)
                throw new ProjectException("Project Cannot be null", new ArgumentException(nameof(project)));
            _projects.Add(project);
        }

        public Project Add(string projectName)
        {
            var project = Project.Create(projectName);
            Add(project);
            return project;
        }

        public Project this[int index]
        {
            get
            {
                if (index < 0 || index >= _projects.Count)
                    throw new IndexOutOfRangeException($"'{index}' is out of range, there are {Count} Projects");
                return _projects[index];
            }
        }
        
        public Project this[string name]
        {
            get
            {
                var project = _projects.FirstOrDefault(x => x.Name.Equals(name));
                if (project == null) throw new ProjectNotFoundException(name);
                return project;
            }
        }
        
        public string Name { get; set; }

        public void AddRange(IEnumerable<Project> projects) => _projects.AddRange(projects);

        #region plumbing

        public int Count => _projects.Count;

        public ProjectCollection() : this(CaseInsensitiveContains.Instance,DEFAULT_PROJECT_COLLECTION_NAME) { }

        public ProjectCollection(StringSearch defaultSearch,string name)
        {
            _defaultSearch = defaultSearch ?? CaseInsensitiveContains.Instance;
            _projects = new List<Project>();
            Name = name;
        }

        public IEnumerator<Project> GetEnumerator() => _projects.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        readonly List<Project> _projects;

        const string DEFAULT_PROJECT_COLLECTION_NAME = "Project Collection";

        #endregion

        public Project GetByName(string projectName) => 
            _projects.FirstOrDefault(x => x.Name.Equals(projectName));

        public bool TryGetByName(string name, out Project p)
        {
            p = _projects.FirstOrDefault(x => x.Name.Equals(name));
            return p != null;
        }

        public bool TryGetAtIndex(int index, out Project p)
        {
            p = index >= 0 && index < _projects.Count ? this[index] : null;
            return p != null;
        }
    }
}