namespace JasonStorey.ProjectManagement
{
    public class CaseInsensitiveContains : StringSearch
    {
        public bool Matches(string search, string value) => 
            !string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(value) && value.ToLower().Contains(search.ToLower());
        
        public static CaseInsensitiveContains Instance => _instance ?? (_instance = new CaseInsensitiveContains());
        static CaseInsensitiveContains _instance;

    }
}