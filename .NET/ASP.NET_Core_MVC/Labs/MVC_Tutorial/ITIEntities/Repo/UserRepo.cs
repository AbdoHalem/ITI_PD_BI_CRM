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
    public class UserRepo : IEntityRepo<User>
    {
        ITIContext context;
        public UserRepo(ITIContext _context)
        {
            context = _context;
        }
        public void Add(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Users.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<User> FindAll(Expression<Func<User, bool>> cond)
        {
            // We MUST use Include here so that when we search for a user during login,
            // Entity Framework brings their roles with them from the UserRoles table.
            return context.Users.Include(u => u.UserRoles).Where(cond).ToList();
        }

        public List<User> GetAll()
        {
            return context.Users.Include(u => u.UserRoles).ToList();
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public void Update(User entity)
        {
            context.Users.Update(entity);
            context.SaveChanges();
        }
    }
}
