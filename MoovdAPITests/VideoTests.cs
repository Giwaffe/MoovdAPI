using System;
using MoovdAPI;
using MoovdAPI.Models;
using MoovdAPI.Models.Repositories;
using Xunit;

namespace MoovdAPITests
{
    public class VideoTests
    {
        [Fact]
        public void AddVideo()
        {
            // Prepare test
            IVideoRepository videoRepository = new VideoRepository();
            Category testCategory = new Category("Test Category");
            Video testVideo = new Video(
                "Test Video 1",
                "This is video 1 for testing purposes",
                testCategory,
                DateTime.Now,
                DateTime.Now,
                "/emdr/videos/",
                "emdr/thumbnails/",
                "Patrick");
            testVideo.Id = 99;

            // Do the thing
            Video getVideoResult = videoRepository.Add(testVideo);
            
            // Assert
            Assert.Equal(testVideo, getVideoResult);
        }
    }
}
