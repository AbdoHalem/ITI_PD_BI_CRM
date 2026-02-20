using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_4
{
    
    internal class Program
    {
        public static void My_BubbleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - i - 1; j++)
                {
                    if (nums[j] > nums[j+1])
                    {
                        int temp = nums[j];
                        nums[j] = nums[j+1];
                        nums[j+1] = temp;
                    }
                }
            }
        }
        // ================================================
        public static int FindMin(int[] nums, int startIndex)
        {
            int minIndex = startIndex;
            for(int i = startIndex+1; i < nums.Length; i++)
            {
                if (nums[i] < nums[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public static void My_SelectionSort(int[] nums)
        {
            int currentIndex = 0;
            while (currentIndex < nums.Length - 1)
            {
                int index_min = FindMin(nums, currentIndex);
                if (index_min != currentIndex)
                {
                    int temp = nums[currentIndex];
                    nums[currentIndex] = nums[index_min];
                    nums[index_min] = temp;
                }
                currentIndex++;
            }
        }
        static void Main(string[] args)
        {
            int[] arr1 = { 64, 34, 25, 12, 22, 11, 90 };
            My_BubbleSort(arr1);
            Console.WriteLine("Sorted array using bubble sort: ");
            foreach (int item in arr1)
            {
                Console.Write(item + " ");
            }
            int []arr2 = {64, 34, 25, 12, 22, 11, 90};
            My_SelectionSort(arr2);
            Console.WriteLine("\nSorted array using selection sort: ");
            foreach (int item in arr2)
            {
                Console.Write(item + " ");
            }
        }
    }
}
