using System;
using System.Collections.Generic;

namespace MoovdAPI.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        // List represents database for now
        private List<Category> categories = new();
        private int nextId = 0;

        public CategoryRepository()
        {
            // Create a few categories
            Category emdr = new Category("EMDR");
            Add(emdr);
            Add(new Category("PTSD", emdr));
            Add(new Category("Specials"));
        }
        
        public IEnumerable<Category> GetAll()
        {
            return categories;
        }

        public Category Get(int id)
        {
            return categories.Find(category => category.Id == id);
        }

        public Category GetByName(string name)
        {
            return categories.Find(category => category.Name == name);
        }

        public Category Add(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            category.Id = nextId++; // Automatic new id for each category, temporary thing
            categories.Add(category);
            return category;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            
            int index = categories.FindIndex(c => c.Id == category.Id);
            if (index == -1)
            {
                return false;
            }
            categories.RemoveAt(index);
            categories.Add(category);
            return true;
        }
    }
}