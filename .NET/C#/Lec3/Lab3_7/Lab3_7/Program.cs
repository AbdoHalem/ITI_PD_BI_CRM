using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_7
{
    internal class Program
    {
        static class ArrayUtils
        {
            public static void Reverse(int[] arr)
            {
                for(int i = 0, j = arr.Length - 1; i < j; i++, j--)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            public static int FindMax(int[] arr)
            {
                int max = arr[0];
                for(int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                }
                return max;
            }
            public static int FindMin(int[] arr)
            {
                int min = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                    }
                }
                return min;
            }
            public static bool isSorted(int[] arr)
            {
                bool sorted = true;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i+1])
                    {
                        sorted = false;
                        break;
                    }
                }
                return sorted;
            }

            public static int CountOccurrences(int[] arr, int value)
            {
                int counter = 0;
                for(int i = 0; i < arr.Length; i++)
                {
                    if(arr[i] == value)
                    {
                        counter++;
                    }
                }
                return counter;
            }
            public static int[] Merge(int[]arr1, int[] arr2)
            {
                int[] result = new int[arr1.Length + arr2.Length];
                int i = 0;
                for(i = 0; i < arr1.Length; i++)
                {
                    result[i] = arr1[i];
                }
                for (int j = 0; j < arr2.Length; j++)
                {
                    result[j+i] = arr2[j];
                }
                return result;
            }
        }
             
        static void Main(string[] args)
        {
            int [] array = { 5, 3, 8, 1, 2 };
            Console.WriteLine("Original array: " + string.Join(", ", array));
            ArrayUtils.Reverse(array);
            Console.WriteLine("Reversed array: " + string.Join(", ", array));
            int maxIndex = ArrayUtils.FindMax(array);
            Console.WriteLine("Max element: " + maxIndex);
            int minIndex = ArrayUtils.FindMin(array);
            Console.WriteLine("Min element: " + minIndex);
            Console.WriteLine("Is this array sorted? {0}", ArrayUtils.isSorted(array) ? "Yes" : "No");
            Console.WriteLine("Occurrences of 3: " + ArrayUtils.CountOccurrences(array, 3));
            int[] arr2 = { 7, 4, 6 };
            Console.WriteLine("Merged array: {0}", string.Join(", ", ArrayUtils.Merge(array, arr2)));
        }
    }
}
