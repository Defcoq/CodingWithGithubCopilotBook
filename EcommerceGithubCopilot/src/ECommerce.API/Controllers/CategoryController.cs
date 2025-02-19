using Microsoft.AspNetCore.Mvc;
using ECommerce.BLL.DTOs;
using ECommerce.BLL.Services;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
        {
            var response = await _categoryService.AddCategoryAsync(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
        {
            var response = await _categoryService.UpdateCategoryAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var request = new DeleteCategoryRequest { Id = id };
            var response = await _categoryService.DeleteCategoryAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var request = new GetAllCategoriesRequest();
            var response = await _categoryService.GetAllCategoriesAsync(request);
            return Ok(response);
        }
    }
}