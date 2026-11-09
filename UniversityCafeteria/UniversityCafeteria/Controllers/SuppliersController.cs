
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

    public IActionResult Index()
    {
        return View(_context.Supplier.Include(s => s.Products).ToList());
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,Name,Phone,Email,Address")] Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            _context.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(supplier);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || _context.Supplier == null)
        {
            return NotFound();
        }
        var supplier = _context.Supplier.Find(id);
        if (supplier == null)
        {
            return NotFound();
        }
        return View(supplier);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Name,Phone,Email,Address")] Supplier supplier)
    {
        if (id != supplier.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Supplier.Update(supplier);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(supplier);
    }

    public IActionResult Details(int? id)
    {
        if (id == null || _context.Supplier == null)
        {
            return NotFound();
        }
        var supplier = _context.Supplier.Find(id);
        if (supplier == null)
        {
            return NotFound();
        }
        return View(supplier);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var supplier = _context.Supplier.Find(id);
        if (supplier == null)
        {
            return NotFound();
        }
        _context.Supplier.Remove(supplier);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
