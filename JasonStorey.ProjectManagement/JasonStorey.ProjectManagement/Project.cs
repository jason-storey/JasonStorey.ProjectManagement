using System;

namespace JasonStorey.ProjectManagement
{
    public class Project
    {
        string _color;

        public static Project Create(string name,string description = "") =>
            new Project
            {
                Name = name,
                Description = description,
                CreatedDate = DateTimeOffset.Now
            };

        public string Description { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTimeOffset CreatedDate { get; set; }

        public string Color
        {
            get => _color;
            set
            {
                if (!Validators.IsHexColor(value))
                    throw new ProjectException($"'{value}' is not a valid hex color",
                        new ArgumentOutOfRangeException(nameof(Color)));
                _color = value;
            }
        }
    }
}