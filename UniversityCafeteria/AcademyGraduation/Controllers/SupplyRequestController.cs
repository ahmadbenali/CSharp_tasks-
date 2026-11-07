using System.Text.Json;
using AcademyGraduation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademyGraduation.Controllers
{
    public class SupplyRequestController : Controller
    {
        private List<OfferInfo> GetAllOffers()
        {
            return new List<OfferInfo>
            {
                new OfferInfo { Id = 1, CategoryId = 1, CategoryName = "Graduation Certificates", SupplierName = "Supplier A", OfferName = "Premium Certificate Package", Quantity = 35, UnitPrice = 2m },
                new OfferInfo { Id = 2, CategoryId = 1, CategoryName = "Graduation Certificates", SupplierName = "Supplier B", OfferName = "Standard Certificate Package", Quantity = 35, UnitPrice = 1.5m },
                new OfferInfo { Id = 3, CategoryId = 1, CategoryName = "Graduation Certificates", SupplierName = "Supplier C", OfferName = "Luxury Certificate Package", Quantity = 35, UnitPrice = 2.5m },

                new OfferInfo { Id = 4, CategoryId = 2, CategoryName = "Hospitality", SupplierName = "Supplier D", OfferName = "Coffee & Drinks Package", Quantity = 100, UnitPrice = 2m },
                new OfferInfo { Id = 5, CategoryId = 2, CategoryName = "Hospitality", SupplierName = "Supplier E", OfferName = "Sandwiches & Snacks Package", Quantity = 100, UnitPrice = 3m },
                new OfferInfo { Id = 6, CategoryId = 2, CategoryName = "Hospitality", SupplierName = "Supplier F", OfferName = "Full Hospitality Package", Quantity = 100, UnitPrice = 4m },

                new OfferInfo { Id = 7, CategoryId = 3, CategoryName = "Graduation Gifts", SupplierName = "Supplier G", OfferName = "Customized Mugs Package", Quantity = 35, UnitPrice = 2m },
                new OfferInfo { Id = 8, CategoryId = 3, CategoryName = "Graduation Gifts", SupplierName = "Supplier H", OfferName = "Graduation Bags Package", Quantity = 35, UnitPrice = 3m },
                new OfferInfo { Id = 9, CategoryId = 3, CategoryName = "Graduation Gifts", SupplierName = "Supplier I", OfferName = "Premium Gift Boxes Package", Quantity = 35, UnitPrice = 4m }
            };
        }

        // Read the list of selected offers from Session
        private List<OfferInfo> GetSelectedOffers()
        {
            string? json = HttpContext.Session.GetString("SelectedOffers");
            if (json == null)
            {
                return new List<OfferInfo>();
            }
            return JsonSerializer.Deserialize<List<OfferInfo>>(json) ?? new List<OfferInfo>();
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            // keep the offers the employee selected before
            ViewBag.SelectedIds = GetSelectedOffers().Select(o => o.Id).ToList();
            return View(GetAllOffers());
        }

        
        [HttpPost]
        public IActionResult Create(int cat1, int cat2, int cat3)
        {
            List<OfferInfo> allOffers = GetAllOffers();

            // the offer must exist and belong to its category
            OfferInfo? offer1 = allOffers.FirstOrDefault(o => o.Id == cat1 && o.CategoryId == 1);
            OfferInfo? offer2 = allOffers.FirstOrDefault(o => o.Id == cat2 && o.CategoryId == 2);
            OfferInfo? offer3 = allOffers.FirstOrDefault(o => o.Id == cat3 && o.CategoryId == 3);

            if (offer1 == null || offer2 == null || offer3 == null)
            {
                ViewBag.Error = "Please select one offer from each category.";
                ViewBag.SelectedIds = new List<int> { cat1, cat2, cat3 };
                return View(allOffers);
            }

            // all offers are saved in one list inside Session
            List<OfferInfo> selected = new List<OfferInfo> { offer1, offer2, offer3 };
            HttpContext.Session.SetString("SelectedOffers", JsonSerializer.Serialize(selected));

            return RedirectToAction("Review");
        }

        public IActionResult Review()
        {
            List<OfferInfo> selected = GetSelectedOffers();

            // the employee must select all three offers first
            if (selected.Count != 3)
            {
                return RedirectToAction("Create");
            }

            decimal grandTotal = 0;
            decimal totalDiscount = 0;
            decimal finalTotal = 0;

            foreach (OfferInfo offer in selected)
            {
                offer.TotalPrice = offer.Quantity * offer.UnitPrice;

                if (offer.TotalPrice > 500)
                {
                    offer.DiscountPercent = 15;
                }
                else if (offer.TotalPrice > 300)
                {
                    offer.DiscountPercent = 10;
                }
                else
                {
                    offer.DiscountPercent = 0;
                }

                offer.DiscountAmount = offer.TotalPrice * offer.DiscountPercent / 100;
                offer.FinalTotal = offer.TotalPrice - offer.DiscountAmount;

                grandTotal += offer.TotalPrice;
                totalDiscount += offer.DiscountAmount;
                finalTotal += offer.FinalTotal;
            }

            ViewBag.GrandTotal = grandTotal;
            ViewBag.TotalDiscount = totalDiscount;
            ViewBag.FinalTotal = finalTotal;

            return View(selected);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
