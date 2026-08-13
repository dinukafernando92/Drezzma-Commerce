using Drezzma.Application.Features.ProductVariants.DTOs;
using Drezzma.Application.Features.ProductVariants.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Drezzma.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductVariantController : ControllerBase
    {
        private readonly IProductVariantService _service;

        public ProductVariantController(
            IProductVariantService service)
        {
            _service = service;
        }

        [HttpGet("product/{productId:guid}")]
        public async Task<ActionResult<IReadOnlyList<ProductVariantDto>>>GetByProductId(Guid productId)
        {
            var variants =
                await _service.GetByProductIdAsync(productId);

            return Ok(variants);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductVariantDto>>GetById(Guid id)
        {
            var variant =
                await _service.GetByIdAsync(id);

            return Ok(variant);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVariantDto>>Create(CreateProductVariantDto dto)
        {
            var variant =
                await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = variant.Id },
                variant);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductVariantDto>>Update(
                Guid id,
                UpdateProductVariantDto dto)
        {
            var variant =
                await _service.UpdateAsync(id, dto);

            return Ok(variant);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}