using System;
using System.Text;

namespace JasonStorey.ProjectManagement.Tests
{
    public static class RandomValues
    {
        static string _stringPrefix = "¿";

        public static Random Random { get; set; } = new Random();
        
        public static string String(int minLength = 1, int maxLength = 50, string exclude = null)
        {
            string result;
            do
            {
                var length = Int32(minLength, maxLength);
                var prefix = _stringPrefix;
                var prefixLength = prefix?.Length ?? 0;

                var sb = new StringBuilder(prefix ?? string.Empty, length);
                for (var index = 0; index < length - prefixLength; index++)
                {
                    sb.Append(Convert.ToChar(Int32(65, 90)));
                }

                result = sb.ToString(0, length);
            } while (!string.IsNullOrEmpty(exclude) && result == exclude);

            return result;
        }
        
        public static int Int32(int minValue, int maxValue) => Random.Next(minValue, maxValue);
    }
}