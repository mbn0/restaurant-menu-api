namespace backend.Dtos.CategoryDtos
{
    public class AddCategoryDto
    {
        public string CatName { get; set; } = string.Empty;
        public byte[]? CatImage { get; set; } = null;
    }
}
