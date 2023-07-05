using System;
using System.Collections.Generic;

namespace DeveloppareEntityFramework.DAL;

public partial class Product
{
    public long ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public long? CategoryId { get; set; }

    public long? ColorId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Color? Color { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
