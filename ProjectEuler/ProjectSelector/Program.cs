using System;
using System.Numerics;

namespace ProjectSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = 0;
            for (var i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    value += i;
            }
            Console.WriteLine(value.ToString());
        }
    }
}
