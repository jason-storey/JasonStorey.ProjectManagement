using System;

namespace JasonStorey.ProjectManagement
{
    public class ProjectNotFoundException : ProjectException
    {
        public string ProjectName { get; set; }
        public ProjectNotFoundException(string projectName) : this($"'{projectName}' Not Found.",null) => 
            ProjectName = projectName;

        public ProjectNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}