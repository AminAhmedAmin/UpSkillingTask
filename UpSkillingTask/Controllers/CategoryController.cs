using Microsoft.AspNetCore.Mvc;
using UpSkillingTask.DTOs.CategoryDtos;
using UpSkillingTask.Services.Interfaces;

namespace UpSkillingTask.Controllers
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

        [HttpGet("GetCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("GetCategory{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound(new { Message = "Category not found." });
            }
            return Ok(category);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDto addCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isSuccess = await _categoryService.AddCategoryAsync(addCategoryDto);
            if (isSuccess)
            {
                return Ok(new { Message = "Category Added successfully." });
            }
            return BadRequest(new { Message = "Failed to add the category." });
        }

        [HttpPut("EditCategory{id}")]
        public async Task<IActionResult> EditCategory(int id, [FromBody] EditCategoryDto editCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = await _categoryService.UpdateCategoryAsync(id, editCategoryDto);
            if (isUpdated)
            {
                return Ok(new { Message = "Category Edited successfully." });
            }
            return NotFound(new { Message = "Category not found." }); // Return message if category was not found
        }

        [HttpDelete("DeleteCategory{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var isDeleted = await _categoryService.DeleteCategoryAsync(id);
            if (isDeleted)
            {
                return Ok(new { Message = "Category Deleted successfully." });
            }
            return NotFound(new { Message = "Category not found." }); // Return message if category was not found
        }
    }
}
