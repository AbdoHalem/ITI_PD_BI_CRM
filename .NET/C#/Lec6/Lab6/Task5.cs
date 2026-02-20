using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Task5
    {
        public static void task5()
        {
            // With List<T> methods:
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int first = numbers.Find(n => n > 5); // 6
            List<int> evens = numbers.FindAll(n => n % 2 == 0); // [2,4,6,8,10]
            bool hasNeg = numbers.Exists(n =>
            {
                if (n < 0)
                {
                    return true;
                }
                return false;
            }); // false
            Console.WriteLine($"First number > 5 in numbers list is: {first}");
            Console.WriteLine("Even numbers are: ");
            foreach (int n in evens)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine("\nDoes numbers have a negative number? {0}", hasNeg ? "Yes": "No");
        }
    }
}
