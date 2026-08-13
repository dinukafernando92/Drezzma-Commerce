using Drezzma.Application.Features.ProductImages.DTOs;
using Drezzma.Application.Features.ProductImages.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Drezzma.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _service;

        public ProductImageController(
            IProductImageService service)
        {
            _service = service;
        }

        [HttpGet("product/{productId:guid}")]
        public async Task<ActionResult<IReadOnlyList<ProductImageDto>>>
            GetByProductId(Guid productId)
        {
            var images =
                await _service.GetByProductIdAsync(productId);

            return Ok(images);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductImageDto>>
            GetById(Guid id)
        {
            var image =
                await _service.GetByIdAsync(id);

            return Ok(image);
        }

        [HttpPost]
        public async Task<ActionResult<ProductImageDto>>
            Create(CreateProductImageDto dto)
        {
            var image =
                await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = image.Id },
                image);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductImageDto>>
            Update(
                Guid id,
                UpdateProductImageDto dto)
        {
            var image =
                await _service.UpdateAsync(id, dto);

            return Ok(image);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}