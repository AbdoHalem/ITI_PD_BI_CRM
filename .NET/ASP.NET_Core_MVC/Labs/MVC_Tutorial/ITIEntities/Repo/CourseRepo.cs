using ITIEntities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITIEntities.Repo
{
    public class CourseRepo : IEntityRepo<Course>
    {
        ITIContext context;  // Create an instance of the ITIContext to interact with the database

        public CourseRepo(ITIContext _context)
        {
            context = _context;  // Initialize the context through dependency injection
        }
        public void Add(Course entity)
        {
            context.Courses.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Courses.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Course> FindAll(Expression<Func<Course, bool>> cond)
        {
            return context.Courses.Where(cond).ToList();
        }

        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.Find(id);
        }

        public void Update(Course entity)
        {
            context.Courses.Update(entity);
            context.SaveChanges();
        } 
    }
}
