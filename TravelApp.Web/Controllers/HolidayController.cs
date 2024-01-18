using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Core.Contracts;
using TravelApp.Core.DTOModels;

namespace TravelApp.Web.Controllers
{
    public class HolidayController : Controller
    {
        private readonly IHolidayService holidayService;
        public HolidayController(IHolidayService _holidayService)
        {
            holidayService = _holidayService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var holidays = await holidayService.GetAllAsync();
            return View(holidays);
        }

        public IActionResult Details(int id)
        {
            var holiday = holidayService.GetByIdAsync(id);
            return View(holiday);
        }
    }
}
