using backend.Dtos.CategoryDtos;
using backend.Models;

namespace backend.Mappers
{
    public static class CategoryMappers
    {
        public static ViewCategoryDto MapCategoryToViewCategoryDto(this Category category)
        {
            return new ViewCategoryDto
            {
                CatId = category.CatId,
                CatName = category.CatName,
                CatImage = category.CatImage
            };
        }
        public static Category MapAddCategoryDtoToCategory(this AddCategoryDto addCategoryDto)
        {
            return new Category
            {
                CatName = addCategoryDto.CatName,
                CatImage = addCategoryDto.CatImage
            };
        }
    }
}
