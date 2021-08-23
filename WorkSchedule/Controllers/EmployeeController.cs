using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSchedule.Models;

namespace WorkSchedule.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Context _context;

        public EmployeeController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var result = _context.Employees.ToList();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult InsertEmployee(Employee _employee)
        {
            using (_context)
            {
                _context.Employees.Add(_employee);
                _context.SaveChanges();
            }

            return Json(_employee);
        }
    }
}
