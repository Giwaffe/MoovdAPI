using System.Collections.Generic;

namespace MoovdAPI.Models.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        Category GetByName(string name);
        Category Add(Category category);
        void Delete(int id);
        bool Update(Category category);
    }
}