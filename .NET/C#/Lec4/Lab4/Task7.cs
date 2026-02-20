using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Task7
    {
        public class Student
        {
            private int id;
            private string name;
            private int age;
            public Student(int id, string name, int age)
            {
                setID(id);
                this.Name = name;
                this.Age = age;
            }
            //Setters & Getters Properties
            public int Id
            {
                get
                {
                    return this.id;
                }
            }
            public void setID(int id)
            {
                if(id <= 0)
                {
                    throw new ArgumentNullException("value");
                }
                this.id = id;
            }

            public string Name
            {
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("value");
                    }
                    this.name = value;
                }
                get
                {
                    return this.name;
                }
            }
            public int Age
            {
                set
                {
                    if(value >= 16 && value <= 100)
                    {
                        this.age = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid age!");
                    }
                }
                get
                {
                    return this.id;
                }
            }
        }
        public static void task7()
        {
            Student s = new Student(1234, "Halem", 24);
            s.Age = 20; // Calls SET
            int a = s.Age; // Calls GET
            s.Age = 10; // Validation fails, age unchanged!
        }
    }
}
