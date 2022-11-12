namespace JasonStorey.ProjectManagement.Tests
{
    public class ProjectBuilder
    {
        Project _project;

        public ProjectBuilder() => _project = new Project();

        public ProjectBuilder WithName(string name)
        {
            _project.Name = name;
            return this;
        }
        
        public ProjectBuilder WithDescription(string description)
        {
            _project.Description = description;
            return this;
        }
        

        public Project Build() => _project;

        public static implicit operator Project(ProjectBuilder b) => b.Build();
    }
}