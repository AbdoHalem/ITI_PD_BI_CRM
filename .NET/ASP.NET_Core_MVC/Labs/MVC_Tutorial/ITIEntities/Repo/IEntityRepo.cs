using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITIEntities.Repo
{
    public interface IEntityRepo<T> where T : class
    {
        List<T> GetAll();  // Method to retrieve all students from the database
        T GetById(int id);  // Method to retrieve students by their ID
        void Add(T entity);  // Method to add a new student to the database
        void Update(T entity);  // Method to update an existing student's information in the database
        void Delete(int id);  // Method to delete a student from the database by their ID
        public List<T> FindAll(Expression<Func<T, bool>> cond);  // Method to find students based on a specified condition (using a lambda expression)
        public T GetDeptCourses(int id)
        {
            return null;
        }
    }
}
