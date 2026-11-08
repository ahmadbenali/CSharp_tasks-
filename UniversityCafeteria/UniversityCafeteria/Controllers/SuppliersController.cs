
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Models;

public class SuppliersController : Controller
{
    private readonly ApplicationDbContext _context;

    public SuppliersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()    
    {
        return View(await _context.Supplier.ToListAsync());
    }
    
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,Products,PurchaseOrders")] Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            _context.Add(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(supplier);
    }

    private bool SupplierExists(int? id)
    {
        return _context.Supplier.Any(e => e.Id == id);
    }
}
