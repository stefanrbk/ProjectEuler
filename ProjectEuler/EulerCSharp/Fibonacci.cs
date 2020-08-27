using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EulerCSharp
{
    public class Fibonacci
    {
        private (int, int) initialValues;
        public Fibonacci(int first, int second) =>
            initialValues = (first - (second - first), second - first);

        public IEnumerator<int> GetEnumerator() =>
            new FibonacciEnumerator(initialValues);
    }
    public sealed class FibonacciEnumerator : IEnumerator<int>
    {
        private (int, int) initialValues;
        private int last;
        public int Current { get; private set; }
        object IEnumerator.Current => Current;

        public FibonacciEnumerator((int last, int current) initial)
        {
            initialValues = initial;
            last = initial.last;
            Current = initial.current;
        }

        public void Dispose() { }
        public bool MoveNext()
        {
            var value = last + Current;
            last = Current;
            Current = value;

            return true;
        }
        public void Reset() =>
            (last, Current) = initialValues;
    }
}
