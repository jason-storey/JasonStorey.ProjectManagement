namespace JasonStorey.ProjectManagement
{
    public class Project
    {
        public static Project Create(string name,string description = "") =>
            new Project
            {
                Name = name,
                Description = description
            };

        public string Description { get; set; }
        public string Name { get; set; }
    }
}