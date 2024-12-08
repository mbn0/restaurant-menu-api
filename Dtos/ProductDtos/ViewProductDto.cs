namespace backend.Dtos {
  public class ViewProductDto {
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal ProductPrice { get; set; }
    public string Description { get; set; } = string.Empty;
    public int? CatId { get; set; }
     public byte[]? ProductImage { get; set; } = null;
  }
}
