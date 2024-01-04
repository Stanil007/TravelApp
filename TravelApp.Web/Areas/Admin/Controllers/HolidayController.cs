using Microsoft.AspNetCore.Mvc;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class HolidayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
