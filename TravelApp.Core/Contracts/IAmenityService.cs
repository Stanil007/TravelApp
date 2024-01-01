using TravelApp.Core.DTOModels;

namespace TravelApp.Core.Contracts
{
    public interface IAmenityService
    {
        Task<IEnumerable<AmenityDto>> GetAllAsync();
        Task<AmenityDto> GetByIdAsync(int id);
        Task<AmenityDto> CreateAsync(AmenityDto amenity);
        Task<AmenityDto> UpdateAsync(AmenityDto amenity);
        Task DeleteAsync(int id);
    }
}
