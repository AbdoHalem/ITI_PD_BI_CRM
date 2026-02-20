using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Task6
    {
        public class Student
        {
            // Auto-implemented Properties
            public int Id { get; set; }
            public string Name { get; set; }
            public float GPA { get; set; }
        }
        // ====================================
        public static void task6()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Ahmed", GPA = 3.5f },
                new Student { Id = 2, Name = "Sara", GPA = 3.8f },
                new Student { Id = 3, Name = "Omar", GPA = 3.2f }
            };
            // Find operations (out of place)
            Student found = students.Find(s => s.GPA > 3.5);
            List<Student> honors = students.FindAll(s => s.GPA >= 3.5);
            // Sort by GPA (inplace)
            students.Sort((a, b) => a.GPA.CompareTo(b.GPA));    // Ascendingly
            foreach(var  student in students)
            {
                Console.WriteLine(student.Id);
                Console.WriteLine(student.Name);
                Console.WriteLine(student.GPA);
                Console.WriteLine();
            }
        }
    }
}
