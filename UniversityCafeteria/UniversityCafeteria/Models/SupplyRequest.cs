using System;
using System.Collections.Generic;

namespace UniversityCafeteria.Models;

public partial class SupplyRequest
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<SupplyItem> SupplyItems { get; set; } = new List<SupplyItem>();
}
