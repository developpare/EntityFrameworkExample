using System;
using System.Collections.Generic;

namespace DeveloppareEntityFramework.DAL;

public partial class Stock
{
    public long WarehouseId { get; set; }

    public long ProductId { get; set; }

    public long StockValue { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
