using Microsoft.AspNetCore.Mvc;
using TravelApp.Core.Contracts;
using TravelApp.Core.DTOModels;

namespace TravelApp.Web.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IAmenityService amenityService;

        public AmenityController(IAmenityService _amenityService)
        {
            amenityService = _amenityService;
        }

        public async Task<IActionResult> Index()
        {
            var amenities = amenityService.GetAllAsync();
            return View(amenities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AmenityDto amenityDto)
        {
            if (ModelState.IsValid)
            {
                await amenityService.CreateAsync(amenityDto);
                return RedirectToAction(nameof(Index));
            }

            return View(amenityDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var amenity = await amenityService.GetByIdAsync(id);
                return View(amenity);
            }
            catch (ArgumentException)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AmenityDto amenityDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await amenityService.UpdateAsync(amenityDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }

            return View(amenityDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var amenity = await amenityService.GetByIdAsync(id);
                return View(amenity);
            }
            catch (ArgumentException)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await amenityService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
