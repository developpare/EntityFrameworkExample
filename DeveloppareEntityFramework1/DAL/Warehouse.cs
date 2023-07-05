using System;
using System.Collections.Generic;

namespace DeveloppareEntityFramework.DAL;

public partial class Warehouse
{
    public long WarehouseId { get; set; }

    public string WarehouseName { get; set; } = null!;

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
