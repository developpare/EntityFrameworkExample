using System;
using System.Collections.Generic;

namespace DeveloppareEntityFramework.DAL;

public partial class Color
{
    public long ColorId { get; set; }

    public string ColorName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
