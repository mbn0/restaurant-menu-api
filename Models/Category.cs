using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Category
{
    public int CatId { get; set; }

    public string? CatName { get; set; }

    public byte[]? CatImage { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
