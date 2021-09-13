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
        [HttpGet]
        public ActionResult GetEmployees()
        {
            var result = _context.Employees.ToList();
            return Ok(result);
        }
    }
}
