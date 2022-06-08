using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M8_LINQ_Debugging_and_Testing
{
    class Debugging
    {
        public static void Example1()
        {
            var numbers = Enumerable.Range(1, 10)
                        .Select(n => n * n)
                        .Select(n => n / 2)
                        .Select(n => n - 5);
            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }

        public static void Example2()
        {
            var numbers = Enumerable.Range(1, 10);
            var squared = numbers.Select(n => n * n);
            var halved = squared.Select(n => n / 2);
            var minusFive = halved.Select(n => n - 5);
            foreach (var n in minusFive)
            {
                Console.WriteLine(n);
            }

        }

        public static void Example3()
        {
            var numbers = Enumerable.Range(1, 10);
            foreach (var n in numbers)
            {
                var step1 = n*n;
                var step2 = step1/2;
                var result = step2 - 5;
                Console.WriteLine(result);
            }

        }

        public static void Example4()
        {
            var numbers = Enumerable.Range(1, 10)
                        .Peek(n => Console.WriteLine("Step 1: {0}",n))
                        .Select(n => n * n)
                        .Peek(n => Console.WriteLine("Step 2: {0}", n))
                        .Select(n => n / 2)
                        .Peek(n => Console.WriteLine("Step 3: {0}", n))
                        .Select(n => n - 5);
            foreach (var n in numbers)
            {
                Console.WriteLine("Result {0}", n);
            }
        }

    }

    static class MyExtensions
    {
        public static IEnumerable<T> Peek<T>(this IEnumerable<T> source, Action<T> peekAction)
        {
            foreach (var element in source)
            {
                peekAction(element);
                yield return element;
            }
        }
    }
}
