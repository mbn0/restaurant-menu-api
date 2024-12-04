namespace backend.Dtos.CategoryDtos
{
    public class ViewCategoryDto
    {
        public int CatId { get; set; }
        public string CatName { get; set; } = string.Empty;
        public byte[]? CatImage { get; set; } = null;
    }
}
