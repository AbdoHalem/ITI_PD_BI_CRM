using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_1
{
    internal class Program
    {
        public static void RotateArray(int []nums, int k)
        {
            int index1 = 0;
            int index2 = nums.Length - 1;
            for (int i = 0; i < k; i++)
            {
                int temp = nums[index2];
                for(int j = index2; j > index1; j--)
                {
                    nums[j] = nums[j-1];

                }
                nums[index1] = temp;
            }
        }
        static void Main(string[] args)
        {
            int []nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            RotateArray (nums, 2);
            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }
        }
    }
}
