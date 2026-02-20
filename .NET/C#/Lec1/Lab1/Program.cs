using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum Job_Type
    {
        FULL_TIME,
        PART_TIME
    }
    public enum Job_Position
    {
        ADMIN,
        ENGINEER,
        TECHNICIAN
    }
    public struct Employee
    {
        public int id;
        public string name;
        public int salary;
        public Job_Type jobType;
        public Job_Position position;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            Console.Write("Enter Employee's ID: ");
            employee.id = int.Parse(Console.ReadLine());
            
            Console.Write("Enter Employee's Name: ");
            employee.name = Console.ReadLine();
            
            Console.Write("Enter Employee's Salary: ");
            employee.salary = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter the job type: ");
            Console.WriteLine("1 => Full time\n2 => part time");
            int jobType = int.Parse(Console.ReadLine());
            if (jobType >= 1 &&  jobType <= 2){
                employee.jobType = (Job_Type)(jobType - 1);
            }

            Console.WriteLine("Enter the job position: ");
            Console.WriteLine("1 => Admin\n2 => Engineer\n3 => Technician");
            int jobPosition = int.Parse(Console.ReadLine());
            // Print employee
            if (jobPosition >= 1 &&  jobPosition <= 3)
            {
                employee.position = (Job_Position)(jobPosition - 1);
            }
            Console.WriteLine("\n--- Employee Details ---");
            Console.WriteLine($"ID: {employee.id}");
            Console.WriteLine($"Name: {employee.name}");
            Console.WriteLine($"Salary: {employee.salary}");
            Console.WriteLine($"Type: {employee.jobType}");
            Console.WriteLine($"Position: {employee.position}");
        }
    }
}
