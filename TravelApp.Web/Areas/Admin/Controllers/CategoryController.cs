using Microsoft.AspNetCore.Mvc;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
