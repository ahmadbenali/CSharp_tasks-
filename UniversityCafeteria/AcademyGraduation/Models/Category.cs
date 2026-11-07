namespace AcademyGraduation.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        // One category has many suppliers
        public List<Supplier> Suppliers { get; set; } = new();
    }
}
