using backend.Dtos;
using backend.Dtos.ProductDtos;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly MenuDbContext _context;
        public ProductRepo(MenuDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(AddProductDto addProductDto)
        {
            var product = addProductDto.MapAddProductDtoToProduct();
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Boolean> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
              return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<ViewProductDto>> GetAllProducts()
        {
            return await _context.Products.Select(product => product.MapProductToViewProductDto()).ToListAsync();
        }
        public async Task<ViewProductDto?> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new ArgumentNullException();
            }
            return product.MapProductToViewProductDto();
        }

        public async Task<Product> EditProduct(EditProductDto editProductDto)
        {
            var product = await _context.Products.FindAsync(editProductDto.ProductId);
            if (product == null)
            {
                throw new ArgumentNullException();
            }
            product.Name = editProductDto.ProductName;
            product.Price = editProductDto.ProductPrice;
            product.CatId = editProductDto.CatId;
            product.Image = editProductDto.ProductImage;
            await _context.SaveChangesAsync();
            return product;
        }
    }

}