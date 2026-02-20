using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public delegate void NotifyHandler(string msg);
    internal class Task2
    {
        public class Notification
        {
            public static void SendEmail(string msg)
            {
                Console.WriteLine(msg);
            }
            public static void SendSMS(string msg)
            {
                Console.WriteLine(msg);
            }
            public static void LogToFile(string msg)
            {
                Console.WriteLine(msg);
            }
        }
        //==================================
        public static void task2()
        {
            NotifyHandler notify = Notification.SendEmail;
            notify += Notification.SendSMS;
            notify += Notification.LogToFile;
            notify("Order Confirmed!");
            notify -= Notification.SendSMS;
            notify("Shipped!");
        }

    }
}
