using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public static class Operations
    {
        public static bool IsEven(int i)
        {
            return (i % 2 == 0);
        }
        public static bool IsOdd(int i)
        {
            return (i % 2 == 1);
        }
        public static bool IsGreaterThan5(int i)
        {
            return (i > 5);
        }
    }
    internal class Task3
    {
        public delegate bool IntFilter(int value);
        public static int[] FilterArray(int[] arr, IntFilter filter)
        {
            ArrayList res = new ArrayList();
            foreach(int i in arr)
            {
                if (filter(i))
                {
                    res.Add(i);
                }
            }
            return ((int[])res.ToArray(typeof(int)));
        }
        // ===========================================
        public static void task3()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] evens = FilterArray(numbers, Operations.IsEven); // [2,4,6,8,10]
            int[] odds = FilterArray(numbers, Operations.IsOdd); // [1,3,5,7,9]
            int[] big = FilterArray(numbers, Operations.IsGreaterThan5);// [6,7,8,9,10]
            Console.WriteLine("Even Numbers: ");
            foreach(int i in evens)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Odd Numbers: ");
            foreach (int i in odds)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Big Numbers: ");
            foreach (int i in big)
            {
                Console.Write(i + " ");
            }
        }

    }
}
