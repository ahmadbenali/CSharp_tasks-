using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityCafeteria.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = "";

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public int CategoryId { get; set; }              // foreign key
        public Category? Category { get; set; }

        public int SupplierId { get; set; }              // foreign key
        public Supplier? Supplier { get; set; }

        //public List<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new();
    }
}
