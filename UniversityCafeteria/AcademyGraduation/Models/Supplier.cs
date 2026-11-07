namespace AcademyGraduation.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Each supplier provides only one offer
        public Offer? Offer { get; set; }
    }
}
