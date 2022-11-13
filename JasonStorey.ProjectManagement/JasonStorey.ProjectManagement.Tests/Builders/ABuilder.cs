using System;

namespace JasonStorey.ProjectManagement.Tests
{
    public class ABuilder<T>
    {
        protected Lazy<T> Object = new Lazy<T>();

        public T Build() => Object.Value;

        public static implicit operator T(ABuilder<T> b) => b.Build();
    }
}