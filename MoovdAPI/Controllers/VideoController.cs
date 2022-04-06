using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoovdAPI.Models;
using MoovdAPI.Models.Repositories;

namespace MoovdAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VideoController : ControllerBase
    {
        private static readonly IVideoRepository VideoRepository = new VideoRepository();

        [HttpGet("~/video")]
        public IEnumerable<Video> GetAllVideos()
        {
            return VideoRepository.GetAll();
        }

        [HttpGet("~/video/id")]
        public Video GetVideo(int id)
        {
            Video video = VideoRepository.Get(id);
            if (video == null)
            {
                throw new Exception("Video does not exist");
            }
            return VideoRepository.Get(id);
        }

        [HttpGet("/video/category")]
        public IEnumerable<Video> GetVideosByCategory(string category)
        {
            return VideoRepository.GetByCategory(category);
        }

        [HttpPost]
        public Video AddVideo(Video video)
        {
            video = VideoRepository.Add(video);
            return video;
        }

        [HttpPut]
        public bool UpdateVideo(Video video)
        {
            bool result = VideoRepository.Update(video);

            if (!result)
            {
                throw new Exception("Video does not exist");
            }

            return result;
        }
    }
}