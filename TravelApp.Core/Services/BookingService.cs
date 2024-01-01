using Microsoft.EntityFrameworkCore;
using TravelApp.Core.Contracts;
using TravelApp.Core.DTOModels;
using TravelApp.Infrastructure.Data;
using TravelApp.Infrastructure.Data.Entities;

namespace TravelApp.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly TravelAppDbContext context;

        public BookingService(TravelAppDbContext _context)
        {
             context = _context;
        }

        public async Task CreateAsync(BookingDto bookingDto)
        {
             var booking = new Booking
             {
                UserId = bookingDto.UserId,
                HolidayId = bookingDto.HolidayId,
                DateBooked = bookingDto.DateBooked
             };

            await context.Bookings.AddAsync(booking);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await context.Bookings.FindAsync(id);

            context.Bookings.Remove(booking);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookingDto>> GetAllAsync()
        {
            return await context.Bookings.Select(b => new BookingDto
            {
                Id = b.Id,
                UserId = b.UserId,
                HolidayId = b.HolidayId,
                DateBooked = b.DateBooked
            })
            .ToListAsync();
        }

        public async Task<BookingDto> GetByIdAsync(int id)
        {
            var booking = await context.Bookings.FindAsync(id);

            if (booking == null)
            {
                throw new ArgumentException("Booking not found");
            }

            return new BookingDto
            {
                Id = booking.Id,
                UserId = booking.UserId,
                HolidayId = booking.HolidayId,
                DateBooked = booking.DateBooked
            };
        }

        public async Task UpdateAsync(BookingDto bookingDto)
        {
            var bookingToUpdate = await context.Bookings.FindAsync(bookingDto.Id);

            if (bookingToUpdate == null)
            {
                throw new ArgumentException("Booking not found");
            }

            bookingToUpdate.UserId = bookingDto.UserId;
            bookingToUpdate.HolidayId = bookingDto.HolidayId;
            bookingToUpdate.DateBooked = bookingDto.DateBooked;
            await context.SaveChangesAsync();
        }
    }
}
