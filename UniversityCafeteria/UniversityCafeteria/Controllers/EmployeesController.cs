
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Data;
using UniversityCafeteria.Models;

public class EmployeesController : Controller
{
    private readonly EmployeesDBContext _context;

    public EmployeesController(EmployeesDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Employees.Include(e => e.Orders).ToList());
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,FullName,Phone,Email,Position,Salary,HireDate")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || _context.Employees == null)
        {
            return NotFound();
        }
        var employee = _context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,FullName,Phone,Email,Position,Salary,HireDate")] Employee employee)
    {
        if (id != employee.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    public IActionResult Details(int? id)
    {
        if (id == null || _context.Employees == null)
        {
            return NotFound();
        }
        var employee = _context.Employees.Include(e => e.Orders).FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        _context.Employees.Remove(employee);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
