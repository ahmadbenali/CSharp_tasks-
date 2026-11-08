using System.ComponentModel.DataAnnotations;

namespace UniversityCafeteria.Models
{
    public class PurchaseOrderes
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required, StringLength(20)]
        public string Status { get; set; } = "Pending";

        public int SupplierId { get; set; }              // foreign key
        public Supplier? Supplier { get; set; }

        public List<PurchaseOrderItem> Items { get; set; } = new();
    }
}
