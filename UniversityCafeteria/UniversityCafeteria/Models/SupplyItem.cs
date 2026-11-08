using System;
using System.Collections.Generic;

namespace UniversityCafeteria.Models;

public partial class SupplyItem
{
    public int Id { get; set; }

    public int SupplyRequestId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public string Priority { get; set; } = null!;

    public virtual SupplyRequest SupplyRequest { get; set; } = null!;
}
