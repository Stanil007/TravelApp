using Microsoft.AspNetCore.Mvc;
using TravelApp.Core.Contracts;
using TravelApp.Core.DTOModels;

namespace TravelApp.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await bookingService.GetAllAsync();
            return View(bookings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingDto bookingDto)
        {
            if (ModelState.IsValid)
            {
                await bookingService.CreateAsync(bookingDto);
                return RedirectToAction(nameof(Index));
            }

            return View(bookingDto);
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var booking = await bookingService.GetByIdAsync(id);
                return View(booking);
            }
            catch (ArgumentException)
            {
                return RedirectToAction(nameof(Index));
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var booking = await bookingService.GetByIdAsync(id);
                return View(booking);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Booking not found");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookingDto bookingDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bookingDto.Id = id;
                    await bookingService.UpdateAsync(bookingDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }

            return View(bookingDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var booking = await bookingService.GetByIdAsync(id);
                return View(booking);
            }
            catch (ArgumentException)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await bookingService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetHolidaysByUser(Guid userID)
        {
            var bookings = await bookingService.GetHolidaysByUserAsync(userID);
            return View(bookings);
        }
    }
}
