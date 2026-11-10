namespace UniversityCafeteria.Models
{
    public class RequestItem
    {
        public int Id { get; set; }

        public int SupplyRequestId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        // unit price of the product at the time of the request
        public decimal Price { get; set; }

        public SupplyRequest? SupplyRequest { get; set; }

        public Product? Product { get; set; }
    }
}
