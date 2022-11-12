using System.Collections;

namespace JasonStorey.ProjectManagement.Tests
{
    public class ContainsInvalidCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { "Lorem Ipsum", "red" };
            yield return new object[] { "IN WEST PHILADELPHIA BORN AND RAISED", "Philly" };
        }
    }
}