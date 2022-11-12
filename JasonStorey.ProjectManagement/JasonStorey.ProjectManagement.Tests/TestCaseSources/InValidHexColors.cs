using System.Collections;

namespace JasonStorey.ProjectManagement.Tests
{
    public class InValidHexColors : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return "";
            yield return "TEST";
            yield return "red";
            yield return "00cc00";
            yield return "#CC";
            yield return "#cc00cc00A";
            yield return "cc#ccAA";
        }
    }
}