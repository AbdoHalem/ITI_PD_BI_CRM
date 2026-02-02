using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Task4
    {
        public class CollectionClass
        {
            private string[] names = new String[10];
            private Dictionary<string, string> config = new Dictionary<string, string>();
            // Integer Indexer
            public string this[int index]
            {
                get
                {
                    if(index >= 0 && index < names.Length)
                    {
                        return names[index];
                    }
                    else
                    {
                        return null;
                    }
                }
                set
                {
                    if (index >= 0 && index < names.Length)
                    {
                        names[index] = value;
                    }
                }
            }
            //String Indexer
            public string this[string key]
            {
                get
                {
                    if (config.ContainsKey(key))
                    {
                        return config[key];
                    }
                    else
                    {
                        return null;
                    }
                }
                set
                {
                    config[key] = value;
                }
            }
        }
        // ==================================
        public static void task4()
        {
            CollectionClass myCollection = new CollectionClass();
            myCollection[0] = "Ahmed";
            myCollection[1] = "Sara";
            myCollection[2] = "Omar";
            myCollection["host"] = "localhost";
            myCollection["port"] = "8080";
            myCollection["db"] = "mydb";
            Console.WriteLine(myCollection[0]);
            Console.WriteLine(myCollection["host"]);

        }
    }
}
