using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Task3
    {
        public class Gradebook
        {
            int size;
            double[] grades;
            public Gradebook(int size)
            {
                this.size = size;
                grades = new double[size];

            }
            // Indexer Declaration
            public double this[int index]
            {
                get
                {
                    if (index >= 0 && index < size)
                        return grades[index];
                    else
                        return -1;
                }
                set
                {
                    if (index >= 0 && index < size)
                        grades[index] = value;
                }
            }
        }
        // ========================================
        public static void task3()
        {
            Gradebook grades = new Gradebook(5);
            grades[0] = 95;
            Console.WriteLine($"grades[0] = {grades[0]}");
        }
    }
}
