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
        private ScheduleController scheduleController = new ScheduleController();

        public DefaultController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewModel myModel = new ViewModel();
            myModel.Employees = _context.Employees.ToList();
            myModel.Schedules = _context.Schedules.ToList();
            ViewBag.Days = ScheduleController.FirstDateOfWeek(2021, 33);
            return View(myModel);
        }
    }
}
