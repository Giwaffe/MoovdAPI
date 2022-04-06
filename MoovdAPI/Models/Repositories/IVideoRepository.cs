using System.Collections.Generic;

namespace MoovdAPI.Models.Repositories
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetAll();
        Video Get(int id);
        IEnumerable<Video> GetByCategory(string categoryName);
        Video Add(Video video);
        void Delete(int id);
        bool Update(Video video);
    }
}