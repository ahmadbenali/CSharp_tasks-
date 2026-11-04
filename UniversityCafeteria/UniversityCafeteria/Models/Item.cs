using System.ComponentModel.DataAnnotations;

namespace UniversityCafeteria.Models
{
    public class Item
    {
        [Required(ErrorMessage = "Product name is required")]
        public string productName { get; set; }

        [Range(1, 10000, ErrorMessage = "Quantity must be between 1 and 10000")]
        public int quantity { get; set; }


        [Required(ErrorMessage = "Category is required")]
        public string category { get; set; }

        [Range(0.01, 100000, ErrorMessage = "Unit price must be greater than 0")]
        public decimal unitPrice { get; set; }

        public string priority { get; set; } = "Normal";

        public decimal total => quantity * unitPrice;
    }
}
