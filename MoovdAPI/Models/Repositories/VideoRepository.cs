using System;
using System.Collections.Generic;
using System.Linq;

namespace MoovdAPI.Models.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        // List represents database for now
        private List<Video> videos = new();
        private static readonly ICategoryRepository CategoryRepository = new CategoryRepository();
        private int nextId = 0;

        // Create a few Video models to work with
        public VideoRepository()
        {
            Category emdr = CategoryRepository.GetByName("EMDR"); // EMDR category
            Category ptsd = CategoryRepository.GetByName("PTSD"); // PTSD subcategory of EMDR
            Add(new Video(
                "EMDR Video 1",
                "This is video 1",
                emdr,
                DateTime.Now,
                DateTime.Now,
                "/emdr/videos/",
                "emdr/thumbnails/",
                "Patrick"));
            Add(new Video(
                "EMDR Video 2",
                "This is video 2",
                ptsd,
                DateTime.Now,
                DateTime.Now,
                "/emdr/videos/",
                "emdr/thumbnails/",
                "Patrick"));
            Add(new Video(
                "EMDR Video 3",
                "This is video 3",
                ptsd,
                DateTime.Now,
                DateTime.Now,
                "/emdr/videos/",
                "emdr/thumbnails/",
                "Patrick"));
        }

        public IEnumerable<Video> GetAll()
        {
            return videos;
        }

        public Video Get(int id)
        {
            return videos.Find(video => video.Id == id);
        }

        public IEnumerable<Video> GetByCategory(string categoryName)
        {
            return videos.Where(video =>
                string.Equals(
                    video.Category.Name,
                    categoryName,
                    StringComparison.OrdinalIgnoreCase));
        }

        public Video Add(Video video)
        {
            if (video == null)
            {
                throw new ArgumentNullException(nameof(video));
            }

            video.Id = nextId++; // new id for each new video
            videos.Add(video); // Add to (database) list
            return video;
        }

        // Delete a video
        public void Delete(int id)
        {
            videos.RemoveAll(video => video.Id == id);
        }

        // Update an existing video
        public bool Update(Video video)
        {
            if (video == null)
            {
                throw new ArgumentNullException(nameof(video));
            }

            // First find the index of the video that will be updated
            int index = videos.FindIndex(v => v.Id == video.Id);
            if (index == -1)
            {
                // Return false if can't be found
                return false;
            }
            // Remove from list and add the updated video, would otherwise be a SQL update statement            
            videos.RemoveAt(index);
            videos.Add(video);
            return true;
        }
    }
}