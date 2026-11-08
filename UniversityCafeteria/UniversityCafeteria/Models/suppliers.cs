using System.ComponentModel.DataAnnotations;

namespace UniversityCafeteria.Models
{
    public class Suppliers
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = "";

        [Required, StringLength(150), EmailAddress]
        public string Email { get; set; } = "";

        [StringLength(20), Phone]
        public string? Phone { get; set; }

        public List<Product> Products { get; set; } = new();
        public List<PurchaseOrder> PurchaseOrders { get; set; } = new();
    }
}
