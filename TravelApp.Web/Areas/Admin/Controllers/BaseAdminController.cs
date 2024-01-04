using Microsoft.AspNetCore.Mvc;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
