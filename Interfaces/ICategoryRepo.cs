using backend.Dtos.CategoryDtos;
using backend.Models;

namespace backend.Interfaces
{
    public interface ICategoryRepo
    {
      Task<List<ViewCategoryDto>> GetAllCategories();
      Task<ViewCategoryDto?> GetCategory(int id);
      Task<Category> AddCategory(AddCategoryDto category);
      Task<Category> UpdateCategory(EditCategoryDto category);
      Task<Boolean> DeleteCategory(int id);
    }
}
