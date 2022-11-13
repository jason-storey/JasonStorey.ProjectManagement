namespace JasonStorey.ProjectManagement.Tests
{
    public class ProjectCollectionBuilder : ABuilder<ProjectCollection>
    {
        public ProjectCollectionBuilder WithName(string name)
        {
            Object.Value.Name = name;
            return this;
        }
    }
}