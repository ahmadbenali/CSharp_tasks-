using System.ComponentModel.DataAnnotations;

namespace UniversityCafeteria.Models
{
    public class Categories
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = "";

        [StringLength(500)]
        public string? Description { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
