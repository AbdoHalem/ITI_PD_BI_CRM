using Lab1.Models;

namespace Lab1.Services
{
    public class CategoryService : ICategoryService
    {
        // Static list to simulate a database
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Fashion" }
        };

        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category GetById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Category item)
        {
            item.Id = _categories.Max(c => c.Id) + 1;
            _categories.Add(item);
        }

        public void Update(int id, Category item)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                existing.Name = item.Name;
            }
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _categories.Remove(item);
            }
        }

    }
}
