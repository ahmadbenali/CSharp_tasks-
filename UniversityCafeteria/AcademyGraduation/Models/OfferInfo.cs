namespace AcademyGraduation.Models
{
    // Simple class used by the controller and views (and saved in Session)
    public class OfferInfo
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
        public string SupplierName { get; set; } = "";
        public string OfferName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Calculated in the Review action
        public decimal TotalPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalTotal { get; set; }
    }
}
