namespace backend.Dtos.ProductDtos
{
    public class EditProductDto
    {
      public int ProductId { get; set; }
      public string ProductName { get; set; } = string.Empty;
      public decimal ProductPrice { get; set; }
      public byte[]? ProductImage { get; set; } = null;
    }
}
