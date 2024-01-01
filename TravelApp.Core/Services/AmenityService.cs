using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using TravelApp.Core.Contracts;
using TravelApp.Core.DTOModels;
using TravelApp.Infrastructure.Data;
using TravelApp.Infrastructure.Data.Entities;

namespace TravelApp.Core.Services
{
    public class AmenityService : IAmenityService
    {
        private readonly TravelAppDbContext context;


        public AmenityService(TravelAppDbContext _context)
        {
            context = _context;
        }

        public async Task CreateAsync(AmenityDto amenityDto)
        {
            var amenity = new Amenity
            {
                Name = amenityDto.Name
            };

            context.Amenities.Add(amenity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var amenity = await context.Amenities.FindAsync(id);

            if (amenity != null)
            {
                context.Amenities.Remove(amenity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AmenityDto>> GetAllAsync()
        {
            return await context.Amenities.Select(a => new AmenityDto
            {
                Name = a.Name
            })
            .ToListAsync();
        }

        public async Task<AmenityDto> GetByIdAsync(int id)
        {
            var amenity = await context.Amenities.FindAsync(id);

            if (amenity == null)
            {
                throw new ArgumentException("Amenity not found");
            }

            return new AmenityDto
            {
                Name = amenity.Name
            };
        }

        public async Task UpdateAsync(AmenityDto amenity)
        {
            var amenityToUpdate = await context.Amenities.FindAsync(amenity.Id);

            if (amenityToUpdate == null)
            {
                throw new ArgumentException("Amenity not found");
            }

            amenityToUpdate.Name = amenity.Name;

            await context.SaveChangesAsync();
        }
    }
}
