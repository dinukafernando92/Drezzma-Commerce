using Drezzma.Application.Features.Products.DTOs;
using Drezzma.Application.Features.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Drezzma.Application.Exceptions;

namespace Drezzma.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductResponse>>> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductResponse>> GetById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            return Ok(product);
        }

        [HttpGet("slug/{slug}")]
        public async Task<ActionResult<ProductResponse>> GetBySlug(string slug)
        {
            var product = await _productService.GetBySlugAsync(slug);

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> Create(CreateProductRequest request)
        {
            var product = await _productService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductResponse>> Update(Guid id,UpdateProductRequest request)
        {
            var product = await _productService.UpdateAsync(id, request);

            return Ok(product);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("details/{slug}")]
        public async Task<ActionResult<ProductDetailDto>>GetDetailsBySlug(string slug)
        {
            var product =
                await _productService.GetDetailsBySlugAsync(slug);

            return Ok(product);
        }
    }
}