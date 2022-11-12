namespace JasonStorey.ProjectManagement.Tests
{
    public class ProjectCollectionBuilder
    {
        ProjectCollection _projectCollection;

        public ProjectCollectionBuilder()
        {
            _projectCollection = new ProjectCollection();
        }

        public ProjectCollectionBuilder WithName(string name)
        {
            _projectCollection.Name = name;
            return this;
        }
        
        public ProjectCollection Build() => _projectCollection;

        public static implicit operator ProjectCollection(ProjectCollectionBuilder b) => b.Build();
        
    }
}