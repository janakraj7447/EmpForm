using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmpForm.Models;
using EmpForm.Entities;

namespace EmpForm.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
   
    public IActionResult EmployeeForm()
    {
        using (var context = new EmployeeDBContext())
        {
         var employeeList=context.EmployeeForms.ToList();
        }
       return View();
    }
    public IActionResult AddEmployee(EmployeeModels employeeModel)
    {
        using (var context = new EmployeeDBContext())
        {
            EmployeeForm employee = new EmployeeForm();
            employee.FirstName = employeeModel.FirstName;
            employee.LastName = employeeModel.LastName;
            employee.Phone = employeeModel.Phone;
            employee.Email = employeeModel.Email;
            context.EmployeeForms.Add(employee);
            context.SaveChanges();
        }
      
        return RedirectToAction(actionName: "Employeelist", controllerName: "Home");
    }
        public IActionResult Employeelist()
    {
        using (var context=new EmployeeDBContext())
        {
            var employeeList=context.EmployeeForms.ToList();
              return View(employeeList);
        }
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
