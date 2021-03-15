using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models.View_Models;
using Shopping.Services.Interface;
using System;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowOrigin")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productService.GetProducts();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await _productService.GetProduct(id);
            if (result == null)
            {
                return NotFound("Product not Found");
            }
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product is null");
            }
            var newProduct = await _productService.AddProduct(product);

            return Ok(newProduct);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id,[FromBody] ProductViewModel product)
        {
            if (product == null)
            {
                return BadRequest("Product is null");
            }
            await _productService.UpdateProduct(id,product);
            return Ok();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteProduct(id);
            return Ok();

        }




    }
}
