using System.Collections;
using System.Collections.Generic;

namespace JasonStorey.ProjectManagement
{
    public class ProjectCollection : IEnumerable<Project>
    {
        #region plumbing

        public int Count => _projects.Count;
        public ProjectCollection() => _projects = new List<Project>();
        public IEnumerator<Project> GetEnumerator() => _projects.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        readonly List<Project> _projects;
        

        #endregion
    }
}