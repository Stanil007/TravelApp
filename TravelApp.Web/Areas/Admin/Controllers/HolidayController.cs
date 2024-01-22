using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelApp.Core.Contracts;
using TravelApp.Core.DTOModels;

namespace TravelApp.Web.Areas.Admin.Controllers
{
    public class HolidayController : BaseAdminController
    {
        private readonly IHolidayService holidayService;
        private readonly ICategoryService categoryService;
        private readonly IAmenityService amenityService;

        public HolidayController(IHolidayService _holidayService,
                                 ICategoryService _categoryService,
                                 IAmenityService _amenityService)
        {
            holidayService = _holidayService;
            categoryService = _categoryService;
            amenityService = _amenityService;
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

        public IActionResult Create()
        {
            var categories = categoryService.GetAllAsync();
            var amenities = amenityService.GetAllAsync();

            ViewBag.Categories = categories;
            ViewBag.Amenities = amenities;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HolidayDto holidayDto, List<int> selectedAmenities)
        {
            if (ModelState.IsValid)
            {
                await holidayService.CreateAsync(holidayDto, selectedAmenities);
                return RedirectToAction(nameof(Index));
            }

            var categories = categoryService.GetAllAsync();
            var amenities = amenityService.GetAllAsync();
            ViewBag.Categories = categories;
            ViewBag.Amenities = amenities;

            return View(holidayDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var holiday = await holidayService.GetByIdAsync(id);
            var categories = await categoryService.GetAllAsync();
            var amenities = await amenityService.GetAllAsync();

            ViewBag.Categories = categories;
            ViewBag.Amenities = amenities;

            return View(holiday);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HolidayDto holidayDto, List<int> selectedAmenities)
        {
            if (ModelState.IsValid)
            {
                await holidayService.UpdateAsync(holidayDto, selectedAmenities);
                return RedirectToAction(nameof(Index));
            }

            var categories = await categoryService.GetAllAsync();
            var amenities = await amenityService.GetAllAsync();

            ViewBag.Categories = categories;
            ViewBag.Amenities = amenities;

            return View(holidayDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var holiday = await holidayService.GetByIdAsync(id);
            return View(holiday);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await holidayService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
