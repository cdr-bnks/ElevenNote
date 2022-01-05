using ElevenNote.Models._11CategoryModels;
using ElevenNote.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService(userId);
            return categoryService;
        }
        
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategories();
            return Ok(category);
        }

        [HttpPost]
        public IHttpActionResult CreateCategory([FromBody]CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetCatgoryById([FromBody] int id)
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategoryById(id);
            return Ok(category);
        }

        [HttpPut]
        public IHttpActionResult CategoryUpdate(CategoryEdit category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveCategory([FromUri]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.DeleteCategory(id))
                return InternalServerError();

            return Ok();
        }
    }
}
