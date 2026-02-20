using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Task1
    {
        public class Person
        {
            public string firstName;
            private string lastName;
            private int age;
            private string city;
            public string FirstName
            {
                set { firstName = value; }
                get { return firstName; }
            }
            public string LastName
            {
                set { lastName = value; }
                get { return lastName; }
            }
            public int Age
            {
                set { age = value; }
                get { return age; }
            }
            public string City
            {
                set { city = value; }
                get { return city; }
            }
        }

        public struct ST_Address
        {
            string street;
            string city;
            public string Street
            {
                set { street = value; }
                get { return street; }
            }
            public string City
            {
                set { city = value; }
                get { return city; }
            }
        }
        public class Employee
        {
            string name;
            ST_Address address;
            public string Name
            {
                set { name = value; }
                get { return name; }
            }
            public ST_Address Address
            {
                set { address = value; }
                get { return address; }
            }
        }

        public static void task1()
        {
            Person p1 = new Person { FirstName = "Ali", LastName = "EZZ", Age = 30, City = "Alexandria" };
            Console.WriteLine($"First Name: {p1.FirstName}, Last Name: {p1.LastName}, Age: {p1.Age}, City: {p1.City}");
            Employee emp1 = new Employee { Name = "Halem", Address = new ST_Address { Street = "Khairallah", City = "Alex" } };
            Console.WriteLine($"Employee Name: {emp1.Name}, Street: {emp1.Address.Street}, City: {emp1.Address.City}");
        }
    }
}
