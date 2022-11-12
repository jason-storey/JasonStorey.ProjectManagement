using System;
using System.Collections;

namespace JasonStorey.ProjectManagement.Tests
{
    public class ValidHexColors : IEnumerable
    {
        const int AMOUNT_TO_GENERATE = 25;
        public IEnumerator GetEnumerator()
        {
            var random = new Random();
            for (int i = 0; i < AMOUNT_TO_GENERATE; i++)
                yield return $"#{random.Next(0x1000000):X6}";
        }
    }
}