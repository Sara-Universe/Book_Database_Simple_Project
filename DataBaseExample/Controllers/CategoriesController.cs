using DataBaseExample.Models;
using DataBaseExample.Services;
using Microsoft.AspNetCore.Mvc;
using DataBaseExample.Dtos;

namespace DataBaseExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto categorydto)
        {
            var created = await _categoryService.AddAsync(categorydto);
            return CreatedAtAction(nameof(GetCategory), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto categorydto)
        {
            if (!await _categoryService.UpdateAsync(id, categorydto))
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!await _categoryService.DeleteAsync(id))
                return NotFound();
            return NoContent();
        }
    }
}
