using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Task1
    {
        public class Date
        {
            private DateTime date;
            public Date() : this(1990, 1, 1)
            {
                //this.date = DateTime.Parse("01/01/1990");
            }
            public Date(int year) : this(year, 1, 1)
            {
                //this.date = new DateTime(year, 1, 1);
            }
            public Date(int year, int month) : this(year, month, 1)
            {
                //this.date = new DateTime(year, month, 1);
            }
            public Date(int year, int month, int day)
            {
                this.date = new DateTime(year, month, day);
            }
            public string dateToString()
            {
                return this.date.ToString("dd/MM/yyyy");
            }
        }
        public static void task1()
        {
            Date d1 = new Date(); // Default: 01/01/1990
            Date d2 = new Date(2024); // 01/01/2024
            Date d3 = new Date(2024, 6); // 01/06/2024
            Date d4 = new Date(2024, 6, 15); // 15/06/2024
            Console.WriteLine("Date instances created successfully {0}.", d1.dateToString());
            Console.WriteLine("Date instances created successfully {0}.", d2.dateToString());
            Console.WriteLine("Date instances created successfully {0}.", d3.dateToString());
            Console.WriteLine("Date instances created successfully {0}.", d4.dateToString());
        }
    }
}
