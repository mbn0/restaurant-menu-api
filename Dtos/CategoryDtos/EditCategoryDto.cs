namespace backend.Dtos.CategoryDtos
{
    public class EditCategoryDto
    {
        public int CatId { get; set; }
        public string CatName { get; set; } = string.Empty;
        public bool Available { get; set; }
        public byte[]? CatImage { get; set; } = null;
    }
}
