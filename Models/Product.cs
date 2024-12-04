using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public byte[]? Image { get; set; }

    public bool Available { get; set; }

    public int? CatId { get; set; }

    public virtual Category? Cat { get; set; }
}
