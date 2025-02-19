using Microsoft.AspNetCore.Mvc;
using ECommerce.BLL.DTOs;
using ECommerce.BLL.Services;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            var response = await _productService.AddProductAsync(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            var response = await _productService.UpdateProductAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var request = new DeleteProductRequest { Id = id };
            var response = await _productService.DeleteProductAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var request = new GetAllProductsRequest();
            var response = await _productService.GetAllProductsAsync(request);
            return Ok(response);
        }
    }
}