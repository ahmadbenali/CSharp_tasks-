
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Models;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Product.Include(p => p.Category).Include(p => p.Supplier).ToList());
    }


    public IActionResult Create()
    {
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
        ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,Name,Description,Price,Quantity,CategoryId,SupplierId")] Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", product.CategoryId);
        ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Name", product.SupplierId);
        return View(product);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || _context.Product == null)
        {
            return NotFound();
        }
        var product = _context.Product.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", product.CategoryId);
        ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Name", product.SupplierId);
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Name,Description,Price,Quantity,CategoryId,SupplierId")] Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", product.CategoryId);
        ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Name", product.SupplierId);
        return View(product);
    }

    public IActionResult Details(int? id)
    {
        if (id == null || _context.Product == null)
        {
            return NotFound();
        }
        var product = _context.Product.Include(p => p.Category).Include(p => p.Supplier).FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _context.Product.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        _context.Product.Remove(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
