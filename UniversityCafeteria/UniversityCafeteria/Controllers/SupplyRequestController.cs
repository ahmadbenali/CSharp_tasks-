using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using UniversityCafeteria.Data;
using UniversityCafeteria.Models;


namespace UniversityCafeteria.Controllers
{
    public class SupplyRequestController : Controller
    {

        private readonly CafeteriaDbContext _db;

        public SupplyRequestController(CafeteriaDbContext db)
        {
            _db = db;
        }

        private const string SessionKey = "SupplyItems";
        public static List<Item> confirmedItems = new List<Item>();

        private void SaveItems(List<Item> items)
        {
            HttpContext.Session.SetString(SessionKey, JsonSerializer.Serialize(items));
        }

        private List<Item> GetItems()
        {
            string? json = HttpContext.Session.GetString(SessionKey);
            return json == null
                ? new List<Item>()
                : JsonSerializer.Deserialize<List<Item>>(json)!;
        }


        private (decimal Subtotal, decimal PreparationFee, decimal Discount, decimal FinalTotal)
        Calculate(List<Item> items)
        {
            decimal subtotal = items.Sum(x => x.total);
            decimal preparationFee = 0;

            foreach (var item in items)
            {
                preparationFee += item.priority switch
                {
                    "Urgent" => 5m,
                    "Emergency" => 10m,
                    _ => 2m
                };
            }

            decimal discountRate = subtotal >= 200 ? 0.15m
                                 : subtotal >= 100 ? 0.10m
                                 : 0m;
            decimal discount = subtotal * discountRate;

            return (subtotal, preparationFee, discount, subtotal + preparationFee - discount);
        }
        private static readonly string[] Priorities = { "Normal", "Urgent", "Emergency" };

        private void FillIndexData()
        {
            ViewBag.Count = GetItems().Count;

            string? saved = Request.Cookies["PreferredPriority"];
            ViewBag.PreferredPriority = saved != null && Priorities.Contains(saved) ? saved : null;
        }
        public IActionResult Index()
        {
            FillIndexData();
            return View();
        }

        [HttpPost]
        public IActionResult Additem(Item item)
        {
            if (!ModelState.IsValid)
            {
                FillIndexData();
                return View("Index");

            }

            List<Item> items = GetItems();

            items.Add(item);
            SaveItems(items);
            return RedirectToAction("Index");
        }
        public IActionResult Review()
        {
            List<Item> items = GetItems();
            var t = Calculate(items);

            ViewBag.Subtotal = t.Subtotal;
            ViewBag.PreparationFee = Math.Round(t.PreparationFee, 2);
            ViewBag.Discount = Math.Round(t.Discount, 2);
            ViewBag.FinalTotal = Math.Round(t.FinalTotal, 2);

            return View(items);
        }

        [HttpPost]
        public IActionResult ConfirmRequest()
        {
            List<Item> items = GetItems();

            if (items.Count == 0)
            {
                TempData["Error"] = "Add at least one product before confirming.";
                return RedirectToAction("Index");
            }

            confirmedItems.AddRange(items);              // confirmed list keeps growing

            HttpContext.Session.Remove(SessionKey);      // draft is cleared

            return RedirectToAction("MyRequests");


        }

        //[HttpPost]
        //public IActionResult ConfirmRequest()
        //{
        //    var request = new SupplyRequest();
        //    request.SupplyItems.Add(new SupplyItem
        //    {
        //        ProductName = "Coffee",
        //        Category = "Hot Drinks",
        //        Quantity = 10,
        //        UnitPrice = 3m,
        //        Priority = "Urgent"
        //    });

        //    _db.SupplyRequests.Add(request);
        //    _db.SaveChanges();                      // nothing is written until this line

        //    return RedirectToAction("MyRequests");
        //}




        [HttpPost]
        public IActionResult ClearDraft()
        {
            HttpContext.Session.Remove(SessionKey);    
            TempData["Message"] = "Draft cleared.";
            return RedirectToAction("Index");
   
        }

        [HttpPost]
        public IActionResult SavePreference(string priority)
        {
            if (!Priorities.Contains(priority))
            {
                TempData["Error"] = "Choose a valid priority.";
                return RedirectToAction("Index");
            }

            Response.Cookies.Append("PreferredPriority", priority, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7),    
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.Lax
            });

            return RedirectToAction("Index");
        }
        public IActionResult MyRequests()
        {
            return View(confirmedItems);
        }


        //public IActionResult MyRequests()
        //{
        //    List<SupplyRequest> requests = _db.SupplyRequests
        //        .Include(r => r.SupplyItems)       // load each request's products too
        //        .ToList();

        //    return View(requests);
        //}



        public IActionResult About()
        {
            ViewBag.ApplicationName = "University Cafeteria Supply Management System";
            ViewBag.FeatureName = "Supply Request Management";
            ViewBag.Description = "This feature helps cafeteria employees create, manage, review, and calculate supply requests.";

            return View();
        }
    }
}
