namespace JasonStorey.ProjectManagement.Tests
{
    public class ProjectBuilder : ABuilder<Project>
    {
        public ProjectBuilder WithName(string name)
        {
            Object.Value.Name = name;
            return this;
        }
        
        public ProjectBuilder WithDescription(string description)
        {
            Object.Value.Description = description;
            return this;
        }
    }
}