using TravelApp.Core.DTOModels;

namespace TravelApp.Core.Contracts
{
    public interface IHolidayService
    {
        Task<IEnumerable<HolidayDto>> GetAllAsync();
        Task<HolidayDto> GetByIdAsync(int id);
        Task CreateAsync(HolidayDto holiday);
        Task UpdateAsync(HolidayDto holiday);
        Task DeleteAsync(int id);
        Task<IEnumerable<HolidayDto>> GetHolidaysByCategoryAsync(int categoryId);
    }
}
