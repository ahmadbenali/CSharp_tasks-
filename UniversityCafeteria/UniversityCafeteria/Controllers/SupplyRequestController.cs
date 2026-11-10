using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SupplyRequestController(CafeteriaDbContext db, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _context = context;
            _userManager = userManager;
        }

        private bool IsAdmin()
        {
            return User.IsInRole("Admin") || User.IsInRole("SuperAdmin");
        }

        // ---------- Supply requests saved in the database (linked to the logged-in user) ----------

        // User sees only his own requests, Admin and SuperAdmin see all requests
        [Authorize]
        public IActionResult Requests()
        {
            var requests = _context.SupplyRequests.AsQueryable();

            if (!IsAdmin())
            {
                var userId = _userManager.GetUserId(User);
                requests = requests.Where(r => r.UserId == userId);
            }

            ViewBag.UserNames = _userManager.Users.ToDictionary(u => u.Id, u => u.UserName);
            return View(requests.OrderByDescending(r => r.CreatedAt).ToList());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Products = _context.Product.Where(p => p.Quantity > 0).ToList();
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(int[] productIds, int[] quantities)
        {
            var items = new List<RequestItem>();
            decimal total = 0;

            for (int i = 0; i < productIds.Length && i < quantities.Length; i++)
            {
                if (quantities[i] <= 0)
                {
                    continue;
                }

                var product = _context.Product.Find(productIds[i]);
                if (product == null)
                {
                    continue;
                }

                if (quantities[i] > product.Quantity)
                {
                    ModelState.AddModelError("", $"Only {product.Quantity} of {product.Name} are available.");
                    continue;
                }

                items.Add(new RequestItem
                {
                    ProductId = product.Id,
                    Quantity = quantities[i],
                    Price = product.Price
                });
                total += product.Price * quantities[i];
            }

            if (items.Count == 0)
            {
                ModelState.AddModelError("", "Select at least one product and enter a quantity.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Products = _context.Product.Where(p => p.Quantity > 0).ToList();
                return View();
            }

            var request = new SupplyRequest
            {
                CreatedAt = DateTime.Now,
                Status = "Pending",
                TotalPrice = total,
                UserId = _userManager.GetUserId(User)
            };
            _context.SupplyRequests.Add(request);
            _context.SaveChanges();   // request.Id is created here

            foreach (var item in items)
            {
                item.SupplyRequestId = request.Id;
                _context.RequestItems.Add(item);
            }
            _context.SaveChanges();

            return RedirectToAction("Requests");
        }

        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = _context.SupplyRequests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            // a normal user can open only his own request
            if (!IsAdmin() && request.UserId != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            ViewBag.Items = _context.RequestItems.Include(i => i.Product).Where(i => i.SupplyRequestId == request.Id).ToList();
            ViewBag.UserName = _userManager.Users.FirstOrDefault(u => u.Id == request.UserId)?.UserName;
            return View(request);
        }

        // Admin and SuperAdmin: approve or reject. User: change quantities of his Pending request
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = _context.SupplyRequests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            if (!IsAdmin())
            {
                if (request.UserId != _userManager.GetUserId(User))
                {
                    return Forbid();
                }
                if (request.Status != "Pending")
                {
                    TempData["Error"] = "Only a Pending request can be edited.";
                    return RedirectToAction("Requests");
                }
            }

            ViewBag.Items = _context.RequestItems.Include(i => i.Product).Where(i => i.SupplyRequestId == request.Id).ToList();
            return View(request);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, string? status, int[] itemIds, int[] quantities)
        {
            var request = _context.SupplyRequests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            if (IsAdmin())
            {
                if (status == "Pending" || status == "Approved" || status == "Rejected")
                {
                    request.Status = status;
                }
            }
            else
            {
                if (request.UserId != _userManager.GetUserId(User))
                {
                    return Forbid();
                }
                if (request.Status != "Pending")
                {
                    TempData["Error"] = "Only a Pending request can be edited.";
                    return RedirectToAction("Requests");
                }

                decimal total = 0;
                for (int i = 0; i < itemIds.Length && i < quantities.Length; i++)
                {
                    var item = _context.RequestItems.Include(x => x.Product)
                        .FirstOrDefault(x => x.Id == itemIds[i] && x.SupplyRequestId == request.Id);
                    if (item == null)
                    {
                        continue;
                    }

                    if (quantities[i] <= 0)
                    {
                        _context.RequestItems.Remove(item);   // quantity 0 removes the item
                        continue;
                    }

                    if (item.Product != null && quantities[i] > item.Product.Quantity)
                    {
                        TempData["Error"] = $"Only {item.Product.Quantity} of {item.Product.Name} are available.";
                        return RedirectToAction("Edit", new { id });
                    }

                    item.Quantity = quantities[i];
                    total += item.Price * item.Quantity;
                }
                request.TotalPrice = total;
            }

            _context.SaveChanges();
            return RedirectToAction("Details", new { id });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var request = _context.SupplyRequests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            if (!IsAdmin())
            {
                if (request.UserId != _userManager.GetUserId(User))
                {
                    return Forbid();
                }
                if (request.Status != "Pending")
                {
                    TempData["Error"] = "Only a Pending request can be deleted.";
                    return RedirectToAction("Requests");
                }
            }

            var items = _context.RequestItems.Where(i => i.SupplyRequestId == id).ToList();
            _context.RequestItems.RemoveRange(items);
            _context.SupplyRequests.Remove(request);
            _context.SaveChanges();

            return RedirectToAction("Requests");
        }

        // ---------- Old session based actions (kept as they were) ----------

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
