
using backend.Dtos.CategoryDtos;
using backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : Controller
    {
        private readonly CategoryRepo _categoryRepo;
        public CatagoryController(CategoryRepo categoryRepo)
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryRepo.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        //AddCategory
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDto category)
        {
            var newCategory = await _categoryRepo.AddCategory(category);
            return CreatedAtAction(nameof(GetCategory), new { id = newCategory.CatId }, newCategory);
        }

        //UpdateCategory
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(EditCategoryDto category)
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryRepo.DeleteCategory(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
