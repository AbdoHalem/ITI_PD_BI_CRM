using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Person
    {
        public Person(string name, int age, string department)
        {
            Name = name;
            Age = age;
            Department = department;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
    }
    internal class Task6
    {
        public static void task6()
        {
            List<Person> persons = [new Person("Halem", 24, "PD"),
                                    new Person("Khaled", 25, "AI"),
                                    new Person("Mounir", 23, "OS")];
            persons.Sort((a, b) => a.Age.CompareTo(b.Age));
            Console.WriteLine("Sorting asc according to age: ");
            foreach (Person person in persons)
            {
                Console.WriteLine(person.Name);
            }
            persons.Sort((a, b) => b.Age.CompareTo(a.Age));
            Console.WriteLine("Sorting desc according to age: ");
            foreach (Person person in persons)
            {
                Console.WriteLine(person.Name);
            }
            persons.Sort((a, b) => a.Name.CompareTo(b.Name));
            Console.WriteLine("Sorting asc according to name: ");
            foreach (Person person in persons)
            {
                Console.WriteLine(person.Name);
            }
            persons.Sort((a, b) => {
                int result = a.Department.CompareTo(b.Department);
                if (result != 0) 
                   return result;
                return a.Name.CompareTo(b.Name);
            });
            Console.WriteLine("Sorting asc according to department: ");
            foreach (Person person in persons)
            {
                Console.WriteLine(person.Name);
            }
        }
    }
}
