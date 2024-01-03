using TravelApp.Core.DTOModels;

namespace TravelApp.Core.Contracts
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetReviewsByHolidayIdAsync(int holidayId);
        Task <IEnumerable<ReviewDto>> GetReviewsByUserIdAsync(Guid userId);
        Task CreateReviewAsync(ReviewDto reviewDto);
        Task DeleteReviewAsync(int reviewId);
        Task UpdateReviewAsync(ReviewDto reviewDto);
    }
}
