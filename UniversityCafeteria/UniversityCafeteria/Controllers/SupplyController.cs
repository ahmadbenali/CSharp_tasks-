using Microsoft.AspNetCore.Mvc;

namespace UniversityCafeteria.Controllers
{
    public class SupplyController : Controller
    {
        public IActionResult Index()
        {
            string[] categories = { "Drinks", "Food", "Snacks", "Hot Drinks", "Cold Drinks" };

            ViewBag.Categories = categories;
            return View();
        }
        public IActionResult Products()
        {
            ViewData["name"] = "Ahmad Ali";
            ViewData["numproduct"] = 5;
            ViewData["title"] = "Cafeteria Products";
            ViewData["products"] = new List<string> { "Water", "Orange Juice", "Coffee", "Sandwich"," Chocolate"  };
            return View();
        }
        public IActionResult Suppliers()
        {
            ViewBag.PageTitle = "Our Suppliers";
            ViewBag.SupplierCount = 3;
            ViewBag.SupplierNames = new string[]
            {
            "Fresh Food Company",
            "Happy Drinks Company",
            "Daily Supplies Company"
            };
            return View();
        }
        public IActionResult CreateRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitRequest()
        {
            string employeeName = Request.Form["EmployeeName"];
            string productName = Request.Form["ProductName"];
            string quantityText = Request.Form["Quantity"];
            string requiredDate = Request.Form["RequiredDate"];

            if (string.IsNullOrWhiteSpace(employeeName))
            {
                ViewBag.IsError = true;
                ViewBag.Message = "Error: Employee Name is required.";
                return View("CreateRequest");
            }
            if (!int.TryParse(quantityText, out int quantity) || quantity <= 0)
            {
                ViewBag.IsError = true;
                ViewBag.Message = "Error: Quantity must be a number greater than 0.";
                return View("CreateRequest");
            }
            ViewBag.IsError = false;
            ViewBag.Message = $"Success: {employeeName} requested {quantity} x {productName} for {requiredDate}.";
            TempData["SuccessMessage"] = ViewBag.Message;
            return RedirectToAction("About");
        }
        public IActionResult About()
        {
            
            return Content(TempData["SuccessMessage"]?.ToString() ?? "No request submitted.");
        }

    }
}
