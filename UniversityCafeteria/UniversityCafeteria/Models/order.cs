namespace UniversityCafeteria.Models
{
    public class order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        // Navigation property
        public Employee? Employee { get; set; }

    }
}
