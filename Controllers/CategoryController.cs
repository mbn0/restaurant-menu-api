
using backend.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using backend.Interfaces;

namespace backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        //GetAllCategories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepo.GetAllCategories();
            return Ok(categories);
        }
        //GetCategory
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int Id)
        {
            var category = await _categoryRepo.GetCategory(Id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        //AddCategory
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDto category)
        {
            var newCategory = await _categoryRepo.AddCategory(category);
            return CreatedAtAction(nameof(GetCategory), new { id = newCategory.CatId }, newCategory);
        }

        //UpdateCategory
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody]EditCategoryDto category)
        {
            try
            {
                var updatedCategory = await _categoryRepo.UpdateCategory(category);
                return Ok(updatedCategory);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //DeleteCategory
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute]int Id)
        {
            var result = await _categoryRepo.DeleteCategory(Id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
