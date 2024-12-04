namespace backend.Dtos.ProductDtos
{
    public class AddProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public int CatId { get; set; }
        public byte[]? ProductImage { get; set; } = null;
    }
}