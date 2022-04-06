using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoovdAPI.Models;
using MoovdAPI.Models.Repositories;

namespace MoovdAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private static readonly ICategoryRepository CategoryRepository = new CategoryRepository();

        [HttpGet("~/category")]
        public IEnumerable<Category> GetAllVideos()
        {
            return CategoryRepository.GetAll();
        }

        [HttpGet("~/category/{id}")]
        public Category GetCategoryById(int id)
        {
            Category category = CategoryRepository.Get(id);
            if (category == null)
            {
                throw new Exception("Category does not exist."); 
            }
            return category;
        }
        
        [HttpGet("~/category/{name}")]
        public Category GetCategory(string name)
        {
            Category category = CategoryRepository.GetByName(name);
            if (category == null)
            {
                throw new Exception("Category does not exist."); 
            }
            return category;
        }
        
        [HttpPost]
        public Category AddCategory(Category category)
        {
            category = CategoryRepository.Add(category);
            return category;
        }

        [HttpPut]
        public bool UpdateCategory(Category category)
        {
            bool result = CategoryRepository.Update(category);

            if (!result)
            {
                throw new Exception("Category does not exist.");
            }

            return result;
        }
    }
}