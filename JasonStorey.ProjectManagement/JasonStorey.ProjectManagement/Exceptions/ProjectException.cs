using System;

namespace JasonStorey.ProjectManagement
{
    public class ProjectException : Exception
    {
        public ProjectException(string message,Exception innerException) : base(message,innerException) { }
    }
}