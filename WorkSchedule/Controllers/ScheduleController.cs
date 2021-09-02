using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itenso.TimePeriod;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using WorkSchedule.Models;

namespace WorkSchedule.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly Context _context;
        public ScheduleController(Context context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FirstDateOfWeek(int year, int weekOfYear)
        {
            if (year == 0 & weekOfYear == 0)
            {
                return BadRequest("Error");
            }
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = Convert.ToInt32(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek) - Convert.ToInt32(jan1.DayOfWeek);
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            System.Globalization.CultureInfo curCulture = System.Globalization.CultureInfo.CurrentCulture;
            int firstWeek = curCulture.Calendar.GetWeekOfYear(jan1, curCulture.DateTimeFormat.CalendarWeekRule, curCulture.DateTimeFormat.FirstDayOfWeek);
            if (firstWeek <= 1)
            {
                weekOfYear -= 1;
            }

            var firstDate = firstWeekDay.AddDays(weekOfYear * 7);
            var allWeekDays = new List<DateTime>();
            var allWeekendDays = new List<DateTime>();
            allWeekDays.Add(firstDate);
            var currentDate = firstDate;
            for (int d = 1; d < 7; d++)
            {

                //if (d == 5 || d == 6)
                //{
                //    currentDate = currentDate.AddDays(1);
                //    allWeekendDays.Add(currentDate);
                //}
                currentDate = currentDate.AddDays(1);
                allWeekDays.Add(currentDate);

            }
            return Ok(allWeekDays);
        }


        [HttpPost]
        public ActionResult InsertSchedule(Schedule schedule)
        {
            using (_context)
            {
                var check = _context.Schedules.FirstOrDefault(x => x.EmployeeId == schedule.EmployeeId && x.Date == schedule.Date);
                if (check == null)
                {
                    _context.Schedules.Add(schedule);
                    _context.SaveChanges();
                }
                
            }
            return Json(schedule);
        }

    }
}
