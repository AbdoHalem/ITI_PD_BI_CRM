using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ITIEntities.Repo
{
    public class StudentRepo : IEntityRepo<Student>
    {
        ITIContext context;
        public StudentRepo(ITIContext _context)
        {
            context = _context;
        }
        /**
         * GetAll method retrieves all students from the database, including their associated department information.
         * It uses Entity Framework Core's Include method to perform eager loading of the related Department data.
         * The result is returned as a list of Student objects, where each Student object includes its related Department data.
         */
        public List<Student> GetAll()
        {
            // Include is used to load related data (Department) along with the main entity (Student)
            return context.Students.Include(s => s.Department).ToList();
        }
        /**
         * GetById method retrieves a single student from the database based on the provided student ID.
         * It uses the SingleOrDefault method to find the student with the matching ID. If no student is found, it returns null.
         * This method does not include related data (like Department) and only returns the Student entity itself.
         */
        public Student GetById(int id)
        {
            // Find a student by its primary key (Id)
            return context.Students.Find(id);
        }
        /**
         * Add method adds a new student to the database. It takes a Student object as a parameter, adds it to the Students DbSet, and then calls SaveChanges to persist the changes to the database.
         * This method assumes that the Student object provided is valid and does not perform any validation or error handling.
         */
        public void Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }
        /**
         * Update method updates an existing student in the database. It takes a Student object as a parameter, updates it in the Students DbSet, and then calls SaveChanges to persist the changes to the database.
         * This method assumes that the Student object provided has a valid ID that corresponds to an existing student in the database. It does not perform any validation or error handling.
         */
        public void Update(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }
        /**
         * Delete method removes a student from the database. It takes a Student object as a parameter, removes it from the Students DbSet, and then calls SaveChanges to persist the changes to the database.
         * This method assumes that the Student object provided has a valid ID that corresponds to an existing student in the database. It does not perform any validation or error handling.
         */
        public void Delete(int id)
        {
            context.Students.Remove(GetById(id));
            context.SaveChanges();
        }
        /**
         * FindAll method retrieves a list of students from the database that match a specified condition. It takes an Expression<Func<Student, bool>> as a parameter, which represents a lambda expression used to filter the students.
         * The method uses the Where method to apply the filter condition to the Students DbSet and returns the matching students as a list.
         * This method allows for flexible querying of students based on various criteria defined in the lambda expression.
         */
        public List<Student> FindAll(Expression<Func<Student, bool>> cond)
        {
            return context.Students.Where(cond).ToList();
        }
    }
}
