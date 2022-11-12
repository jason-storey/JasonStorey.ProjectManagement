using System.Collections;

namespace JasonStorey.ProjectManagement.Tests
{
    public class ContainsValidCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { "Lorem Ipsum", "lorem" };
            yield return new object[] { "IN WEST PHILADELPHIA BORN AND RAISED", "born" };
        }
    }
}