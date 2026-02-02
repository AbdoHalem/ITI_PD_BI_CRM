using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Task8
    {
        public class Resource
        {
            // Methods
            public Resource(string name)
            {
                Name = name;
            }
            public string Name
            { get; set; }
            public void Open()
            {
                Console.WriteLine("File is opened successfully");
            }
            public string Read()
            {
                if(Name == "")
                {
                    throw new Exception("Empty file name!");
                }
                Console.WriteLine("Reading file...");
                return "File content";
            }
            public void Close()
            {
                Console.WriteLine("File is closed successfully");
            }
        }
        public static void task8()
        {
            Resource file = new Resource("data.txt");
            try
            {
                file.Open();
                string data = file.Read();
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            finally
            {
                file.Close();
            }

        }
    }
}
