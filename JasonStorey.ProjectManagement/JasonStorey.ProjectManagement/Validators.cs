using System.Text.RegularExpressions;

namespace JasonStorey.ProjectManagement
{
    public static class Validators
    {
        /// <summary>
        /// Matches #argb
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsHexColor(string str)
        {
            string regex = "^#(?:[0-9a-fA-F]{3,4}){1,2}$";
            return Regex.IsMatch(str, regex);
        }
        
        
    }
}