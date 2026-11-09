
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Data;
using UniversityCafeteria.Models;

public class OrdersController : Controller
{
    private readonly EmployeesDBContext _context;

    public OrdersController(EmployeesDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Orders.Include(o => o.Employee).ToList());
    }

    public IActionResult Create()
    {
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,CustomerName,OrderDate,TotalPrice,Status,EmployeeId")] order order)
    {
        if (ModelState.IsValid)
        {
            _context.Add(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", order.EmployeeId);
        return View(order);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || _context.Orders == null)
        {
            return NotFound();
        }
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            return NotFound();
        }
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", order.EmployeeId);
        return View(order);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,CustomerName,OrderDate,TotalPrice,Status,EmployeeId")] order order)
    {
        if (id != order.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", order.EmployeeId);
        return View(order);
    }

    public IActionResult Details(int? id)
    {
        if (id == null || _context.Orders == null)
        {
            return NotFound();
        }
        var order = _context.Orders.Include(o => o.Employee).FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            return NotFound();
        }
        _context.Orders.Remove(order);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
