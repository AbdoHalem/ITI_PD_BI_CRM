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
    public class DepartmentRepo : IEntityRepo<Department>
    {
        ITIContext context;

        public DepartmentRepo(ITIContext _context)
        {
            context = _context;
        }
        public void Add(Department entity)
        {
            context.Departments.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Departments.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.Find(id);
        }

        public void Update(Department entity)
        {
            context.Departments.Update(entity);
            context.SaveChanges();
        }

        public Department GetDeptCourses(int id)
        {
            return context.Departments.Include(d=>d.Courses).FirstOrDefault(d => d.DeptId == id);
        }

        public List<Department> FindAll(Expression<Func<Department, bool>> cond)
        {
            return context.Departments.Where(cond).ToList();
        }
    }
}
