using backend.Dtos.ProductDtos;
using backend.Interfaces;
using backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        //GetAllProducts
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepo.GetAllProducts();
            return Ok(products);
        }

        //GetProduct
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int Id)
        {
            var product = await _productRepo.GetProduct(Id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //AddProduct
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]AddProductDto product, IFormFile image)
        {
            var newProduct = await _productRepo.AddProduct(product, image);
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

        //UpdateProduct
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] EditProductDto product)
        {
            try
            {
                var updatedProduct = await _productRepo.EditProduct(product);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //DeleteProduct
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int Id)
        {
            var result = await _productRepo.DeleteProduct(Id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpPut("{Id}/disable")]
        public async Task<IActionResult> DisableProduct([FromRoute]int Id)
        {
            var result = await _productRepo.DisableProduct(Id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{Id}/enable")]
        public async Task<IActionResult> EnableProduct([FromRoute]int Id)
        {
            var result = await _productRepo.EnableProduct(Id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}

