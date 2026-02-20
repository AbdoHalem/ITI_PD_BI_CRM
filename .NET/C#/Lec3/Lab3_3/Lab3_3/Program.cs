using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Jagged Array
            int[][] jaggedArray = new int[6][];
            // Apply pascal triangle logic to fill the jagged array
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new int[i+1];
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (i == 0)
                    {
                        jaggedArray[i][j] = 1;
                        break;
                    }
                    else if (j == 0 || j == jaggedArray[i].Length - 1)
                    {
                        jaggedArray[i][j] = 1;
                    }
                    else
                    {
                        jaggedArray[i][j] = jaggedArray[i-1][j-1] + jaggedArray[i-1][j];
                    }
                }
            }
            // Print the jagged array
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
