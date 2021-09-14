using Microsoft.AspNetCore.Mvc;
using WorkSchedule.Models;

namespace WorkSchedule.Controllers
{
    public class SubmitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
