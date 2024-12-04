using backend.Dtos;
using backend.Dtos.ProductDtos;
using backend.Models;

namespace backend.Mappers
{
    public static class ProductMappers
    {
        public static Product MapAddProductDtoToProduct(this AddProductDto addProductDto)
        {
            return new Product
            {
                Name = addProductDto.ProductName,
                Price = addProductDto.ProductPrice,
                CatId = addProductDto.CatId,
                Image = addProductDto.ProductImage
            };
        }
        public static ViewProductDto MapProductToViewProductDto(this Product product)
        {
            return new ViewProductDto
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductPrice = product.Price,
                CatId = product.CatId,
                ProductImage = product.Image
            };
        }
    }
}
