using backend.Dtos.CategoryDtos;
using backend.Models;

namespace backend.Mappers
{
    public static class CategoryMappers
    {
        public static ViewCategoryDto CategoryToViewCategoryDto(this Category category)
        {
            return new ViewCategoryDto
            {
                CatId = category.CatId,
                CatName = category.CatName,
                CatImage = category.CatImage
            };
        }
        public static Category AddCategoryDtoToCategory(this AddCategoryDto addCategoryDto)
        {
            return new Category
            {
                CatName = addCategoryDto.CatName,
                CatImage = addCategoryDto.CatImage
            };
        }
    }
}
