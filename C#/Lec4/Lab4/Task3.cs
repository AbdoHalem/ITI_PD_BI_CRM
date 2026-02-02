using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Task3
    {
        public abstract class Employee
        {
            protected int id;
            protected string name;
            protected int baseSalary;
            public Employee(int id, string name, int baseSalary)
            {
                this.ID = id;
                this.Name = name;
                this.BaseSalary = baseSalary;
            }
            // Setters and Getters Properties
            public int ID
            {
                set {
                    if(value <= 0)
                        throw new ArgumentException("ID must be positive.");
                    this.id = value;
                }
                get { return this.id; }
            }
            public string Name
            {
                set {
                    if(string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Name cannot be empty.");
                    this.name = value;
                }
                get { return this.name; }
            }
            public int BaseSalary
            {
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("ID must be positive.");
                    this.baseSalary = value;
                }
                get { return this.baseSalary; }
            }
            // Methods
            public abstract void DisplayInfo();
            // Abstract Method to be implemented in derived classes
            public abstract int CalculateSalary();
        }
        // Derived Class: Manager
        public class Manager: Employee
        {
            private int bonus;
            private int teamSize;
            public Manager(int id, string name, int baseSalary, int bonus, int teamSize)
                : base(id, name, baseSalary)
            {
                this.Bonus = bonus;
                this.TeamSize = teamSize;
            }
            // Setters and Getters Properties
            public int Bonus
            {
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Bonus cannot be negative.");
                    this.bonus = value;
                }
                get { return this.bonus; }
            }
            public int TeamSize
            {
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Team size cannot be negative.");
                    this.teamSize = value;
                }
                get { return this.teamSize; }
            }
            // Override Methods
            public override void DisplayInfo()
            {
                Console.WriteLine("Manager ID: {0}, Name: {1}, Base Salary: {2}, Bonus: {3}, Team Size: {4}",
                    this.ID, this.Name, this.BaseSalary, this.Bonus, this.TeamSize);
            }
            public override int CalculateSalary()
            {
                return this.BaseSalary + this.Bonus;
            }
        }
        public static void task3()
        {
            Employee emp = new Manager(1, "Halem", 5000, 1000, 5);
            emp.DisplayInfo();
            Console.WriteLine("Total Salary: {0}", emp.CalculateSalary());
        }

    }
}
