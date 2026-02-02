using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Task2
    {
        public class Counter
        {
            private static int totalObjectsCreated;
            private int instanceID;
            static Counter()
            {
                totalObjectsCreated = 0;
            }
            public Counter()
            {
                totalObjectsCreated++;
                this.instanceID = totalObjectsCreated;
            }
            public int getID()
            {
                return this.instanceID;
            }
            
        }
        public static void task2()
        {
            Counter c1 = new Counter(); // Instance constructor runs
            Counter c2 = new Counter(); // Instance constructor runs
            Counter c3 = new Counter(); // Instance constructor runs
            Console.WriteLine(c1.getID()); // Returns 1
            Console.WriteLine(c2.getID()); // Returns 2
            Console.WriteLine(c3.getID()); // Returns 3
        }
    }
}
