namespace JasonStorey.ProjectManagement.Tests
{
    public static class A
    {
        public static Fakers Fake => Fakers.Instance;
        
        public static ProjectBuilder Project => new ProjectBuilder();
        
        public static ProjectCollectionBuilder ProjectCollection => new ProjectCollectionBuilder();
    }
}