using TravelApp.Core.DTOModels;

namespace TravelApp.Core.Contracts
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllAsync();
        Task<BookingDto> GetByIdAsync(int id);
        Task CreateAsync(BookingDto booking);
        Task UpdateAsync(BookingDto booking);
        Task DeleteAsync(int id);
    }
}
