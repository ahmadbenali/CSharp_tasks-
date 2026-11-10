using System;
using System.Collections.Generic;

namespace UniversityCafeteria.Models;

public partial class SupplyRequest
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Status { get; set; } = null!;

    // Status values: Pending, Approved, Rejected
    // CreatedAt is the request date

    public decimal TotalPrice { get; set; }

    // Id of the user (AspNetUsers) who created the request
    public string? UserId { get; set; }

    public virtual ICollection<SupplyItem> SupplyItems { get; set; } = new List<SupplyItem>();
}
