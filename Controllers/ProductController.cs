using backend.Dtos.CategoryDtos;
using backend.Dtos.ProductDtos;
using backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepo _productRepo;
        public ProductController(ProductRepo productRepo)
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepo.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        //AddProduct
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto product)
        {
            var newProduct = await _productRepo.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }
        //UpdateProduct
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(EditProductDto product)
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productRepo.DeleteProduct(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpPut("{id}/disable")]
        public async Task<IActionResult> DisableProduct(int id)
        {
            var result = await _productRepo.DisableProduct(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}/enable")]
        public async Task<IActionResult> EnableProduct(int id)
        {
            var result = await _productRepo.EnableProduct(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}

