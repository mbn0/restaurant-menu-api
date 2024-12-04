using backend.Dtos;
using backend.Dtos.ProductDtos;
using backend.Models;

namespace backend.Interfaces
{
    public interface IProductRepo
    {
      Task<List<ViewProductDto>> GetAllProducts();
      Task<ViewProductDto?> GetProduct(int id);
      Task<Product> AddProduct(AddProductDto product);
      Task<Product> EditProduct(EditProductDto product);
      Task<Boolean> DeleteProduct(int id);
    }
}
