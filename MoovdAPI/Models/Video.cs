using System;

namespace MoovdAPI.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public Category Category { get; }
        public DateTime InsertTime { get; }
        public DateTime DeleteTime { get; }
        public string VideoLocation { get; }
        public string ThumbnailLocation { get; }
        public string ApprovedBy { get; }

        public Video()
        {
        }

        public Video(
            string name, 
            string description,
            Category category,
            DateTime insertTime,
            DateTime deleteTime,
            string videoLocation,
            string thumbnailLocation,
            string approvedBy)
        {
            Name = name;
            Description = description;
            Category = category;
            InsertTime = insertTime;
            DeleteTime = deleteTime;
            VideoLocation = videoLocation;
            ThumbnailLocation = thumbnailLocation;
            ApprovedBy = approvedBy;
        }
    }
}
