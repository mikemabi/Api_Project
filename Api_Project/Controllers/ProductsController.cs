using ApiProject.Application.Dto;
using ApiProject.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult SayHello()
        {

            try
            {
                var number = 5;
                var result = number / 0;
                return NotFound(new List<string> { "Bisi", "Tayo", "Funke", "David", "Osi" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetAllProducts() 
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]ProductDto productDto)
        {
            await _productService.AddProductAsync(productDto);
            return Created("api/products/id", "Product was added successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,  [FromBody]ProductDto productDto)
        {
            await _productService.EditProductAsync(id, productDto);
            return Ok("Product was edited successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Product successfully deleted");
        }
    }
}
