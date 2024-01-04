using Microsoft.AspNetCore.Mvc;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
