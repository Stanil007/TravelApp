using Microsoft.EntityFrameworkCore;
using TravelApp.Core.Contracts;
using TravelApp.Core.DTOModels;
using TravelApp.Infrastructure.Data;
using TravelApp.Infrastructure.Data.Entities;

namespace TravelApp.Core.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly TravelAppDbContext context;

        public HolidayService(TravelAppDbContext _context)
        {
            context = _context;
        }

        public async Task CreateAsync(HolidayDto holidayDto)
        {
            var holiday = new Holiday
            {
                CategoryId = holidayDto.CategoryId,
                Destination = holidayDto.Destination,
                Description = holidayDto.Description,
                ImageUrl = holidayDto.ImageUrl,
            };

            await context.Holidays.AddAsync(holiday);

            var selectedAmenityIds = holidayDto.AmenitiesIds;

            var amenitiesToAdd = await context.Amenities
                .Where(a => selectedAmenityIds.Contains(a.Id))
                .ToListAsync();

            holiday.Amenities = amenitiesToAdd;

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var holiday = await context.Holidays.FindAsync(id);

            context.Holidays.Remove(holiday);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HolidayDto>> GetAllAsync()
        {
            return await context.Holidays.Select(h => new HolidayDto
            {
                Id = h.Id,
                CategoryId = h.CategoryId,
                Destination = h.Destination,
                Description = h.Description,
                ImageUrl = h.ImageUrl
            })
            .ToListAsync();
        }

        public async Task<HolidayDto> GetByIdAsync(int id)
        {
            var holiday = await context.Holidays.FindAsync(id);

            return new HolidayDto
            {
                Id = holiday.Id,
                CategoryId = holiday.CategoryId,
                Destination = holiday.Destination,
                Description = holiday.Description,
                ImageUrl = holiday.ImageUrl
            };
        }

        public async Task<IEnumerable<HolidayDto>> GetHolidaysByCategoryAsync(int categoryId)
        {
            var holidays = await context.Holidays
                .Where(h => h.CategoryId == categoryId)
                .Select(h => new HolidayDto
                {
                    Id = h.Id,
                    CategoryId = h.CategoryId,
                    Destination = h.Destination,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl
                })
                .ToListAsync();

            return holidays;
        }

        public async Task UpdateAsync(HolidayDto holiday)
        {
            var holidayToUpdate = await context.Holidays.FindAsync(holiday.Id);

            holidayToUpdate.CategoryId = holiday.CategoryId;
            holidayToUpdate.Destination = holiday.Destination;
            holidayToUpdate.Description = holiday.Description;
            holidayToUpdate.ImageUrl = holiday.ImageUrl;

            context.Holidays.Update(holidayToUpdate);
            await context.SaveChangesAsync();
        }
    }
}
