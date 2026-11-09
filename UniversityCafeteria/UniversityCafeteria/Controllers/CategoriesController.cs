
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using UniversityCafeteria.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class CategoriesController : Controller
{
//4.	Edit(GET) : Display the selected category information.
//5.	Edit(POST) : Update the selected category.
//6.	Details: Display category details in a separate page.
//7.	Delete: Delete the selected category.

    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()    
    {

        return View(_context.Category.Include(c => c.Products).ToList());
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,Name,Description")] Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || _context.Category == null)
        {
            return NotFound();
        }
        var category = _context.Category.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Name,Description")] Category category)
    {
        if (id != category.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
           
           _context.Category.Update(category);
           _context.SaveChanges();
         
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int? id)
    {
        if (id == null || _context.Category == null)
        {
            return NotFound();
        }
        var category = _context.Category.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var category = _context.Category.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        _context.Category.Remove(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
