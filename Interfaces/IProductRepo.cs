using backend.Dtos;
using backend.Dtos.ProductDtos;
using backend.Models;

namespace backend.Interfaces
{
    public interface IProductRepo
    {
      Task<List<ViewProductDto>> GetAllProducts();
      Task<ViewProductDto?> GetProduct(int Id);
      Task<Product> AddProduct(AddProductDto product, IFormFile image);
      Task<Product> EditProduct(EditProductDto product);
      Task<Boolean> DeleteProduct(int Id);
      Task<Boolean> DisableProduct(int catId);
      Task<Boolean> EnableProduct(int Id);
      Task<Boolean> AssignProductToCategory(int productId, int catId);
    }
}
