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
    public class StudentCourseRepo : IEntityRepo<StudentCourse>
    {
        ITIContext context;
        public StudentCourseRepo(ITIContext _context)
        {
            context = _context;
        }
        public void Add(StudentCourse entity)
        {
            context.StudentCourses.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.StudentCourses.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<StudentCourse> FindAll(Expression<Func<StudentCourse, bool>> cond)
        {
            return context.StudentCourses.Where(cond).ToList();
        }

        public List<StudentCourse> GetAll()
        {
            return context.StudentCourses.Include(s => s.Student).ToList();
        }

        public StudentCourse GetById(int id)
        {
            return context.StudentCourses.Find(id);
        }

        public void Update(StudentCourse entity)
        {
            context.StudentCourses.Update(entity);
            context.SaveChanges();
        }
    }
}
