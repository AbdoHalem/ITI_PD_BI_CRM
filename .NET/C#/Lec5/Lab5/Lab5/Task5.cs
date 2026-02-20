using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Task5
    {
        public ArrayList cart = new ArrayList();
        public Task5()
        {
            // Can add ANY type (not type-safe!)
            cart.Add(42); // int
            cart.Add("Hello"); // string
            cart.Add(3.14); // double
            cart.Add(DateTime.Now); // DateTime
            //cart.Sort(); // Sort items (if not same type => runtime error!)
            cart.Reverse(); // Reverse order
            cart.Remove(42); // Remove item
        }
        public static void task5()
        {
            Task5 task = new Task5();
            foreach(var item in task.cart)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}
