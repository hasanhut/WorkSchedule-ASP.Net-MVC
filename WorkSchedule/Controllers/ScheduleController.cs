using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itenso.TimePeriod;
using WorkSchedule.Models;

namespace WorkSchedule.Controllers
{
    public class ScheduleController : Controller
    {
        private Context dbContext = new Context();

        public ActionResult Index()
        {
            ViewBag.Days = FirstDateOfWeek(2021, 33);
            return View();
        }

        public static List<DateTime> FirstDateOfWeek(int year, int weekOfYear)
        {
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
            allWeekDays.Add(firstDate);
            var currentDate = firstDate;
            for (int d = 1; d < 7; d++)
            {
                currentDate = currentDate.AddDays(1);
                allWeekDays.Add(currentDate);
            }
            return allWeekDays;
        }
    }
}
