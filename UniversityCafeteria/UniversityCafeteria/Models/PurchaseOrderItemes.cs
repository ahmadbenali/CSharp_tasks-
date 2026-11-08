using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityCafeteria.Models
{
    public class PurchaseOrderItemes
    {
        public int Id { get; set; }

        public int PurchaseOrderId { get; set; }         // foreign key
        public PurchaseOrder? PurchaseOrder { get; set; }

        public int ProductId { get; set; }               // foreign key
        public Product? Product { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 1000000)]
        public decimal UnitPrice { get; set; }
    }
}
