using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSchedule.Models;

namespace WorkSchedule.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewModel myModel = new ViewModel();
            myModel.Employees = _context.Employees.ToList();
            myModel.Schedules = _context.Schedules.ToList();
            return View(myModel);
        }
    }
}
