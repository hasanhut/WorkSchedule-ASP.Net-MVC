using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public IActionResult GetSchedules()
        {
            var result = _context.Schedules.ToList();
            return Ok(result);
        }
        public ActionResult FirstDateOfWeek(int year, int weekOfYear)
        {
            if (year == 0 & weekOfYear == 0)
            {
                return BadRequest("Error");
            }
            DateTime jan1 = new DateTime(year,1,1);

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
            allWeekDays.Add(firstDate);
            var currentDate = firstDate;
            for (int d = 1; d < 7; d++)
            {
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
                var check = _context.Schedules.Where(
                    x => x.Date == schedule.Date && x.EmployeeId == schedule.EmployeeId && x.Week == schedule.Week && x.Year == schedule.Year)
                    .FirstOrDefault();
                if (check == null)
                {
                    _context.Schedules.Add(schedule);
                    _context.SaveChanges();
                }
                else if (check.SwType != schedule.SwType)
                {
                    check.SwType = schedule.SwType;
                    _context.Entry(check).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return Ok(schedule);
        }

    }
}
