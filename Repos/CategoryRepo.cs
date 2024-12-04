using backend.Dtos.CategoryDtos;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private MenuDbContext _context;

        public CategoryRepo(MenuDbContext context)
        {
            _context = context;
        }

        public async Task<List<ViewCategoryDto>> GetAllCategories()
        {
            var categorys = await _context.Categories.ToListAsync();
            var viewCategorys = categorys.Select(category => category.CategoryToViewCategoryDto()).ToList();

            return viewCategorys;
        }

        public async Task<ViewCategoryDto?> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            var catDto = category?.CategoryToViewCategoryDto();
            return catDto;
        }

        public async Task<Boolean> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Category> AddCategory(AddCategoryDto category)
        {
            var newCategory = category.AddCategoryDtoToCategory();
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;
        }

        public async Task<Category> UpdateCategory(EditCategoryDto category)
        {
          var cat = _context.Categories.Find(category.CatId);
          if (cat == null)
          {
              throw new Exception("Category not found");
          }
          cat.CatName = category.CatName;
          cat.CatImage = category.CatImage;
          _context.Categories.Update(cat);
          await _context.SaveChangesAsync();
          return cat;
        }
    }
}

