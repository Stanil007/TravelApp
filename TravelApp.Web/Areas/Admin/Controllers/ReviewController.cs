using Microsoft.AspNetCore.Mvc;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
