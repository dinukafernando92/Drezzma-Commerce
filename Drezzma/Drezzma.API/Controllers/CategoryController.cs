using Drezzma.Application.Exceptions;
using Drezzma.Application.Features.Categories.DTOs;
using Drezzma.Application.Features.Categories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Drezzma.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{ID:guid}")]
        public async Task<IActionResult> GetById(Guid ID)
        {
            var category = await _categoryService.GetByIdAsync(ID);
            if (category == null)
            {
                throw new NotFoundException("Category not found");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var category = await _categoryService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { ID = category.Id }, category);

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id,UpdateCategoryDto dto)
        {
            var category = await _categoryService.UpdateAsync(id, dto);

            return Ok(category);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.DeleteAsync(id);

            return NoContent();
        }
    }
}
