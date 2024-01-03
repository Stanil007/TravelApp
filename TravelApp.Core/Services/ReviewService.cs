using Microsoft.EntityFrameworkCore;
using TravelApp.Core.Contracts;
using TravelApp.Core.DTOModels;
using TravelApp.Infrastructure.Data;
using TravelApp.Infrastructure.Data.Entities;

namespace TravelApp.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly TravelAppDbContext context;

        public ReviewService(TravelAppDbContext _context)
        {
            context = _context;
        }

        public async Task CreateReviewAsync(ReviewDto reviewDto)
        {
            var review = new Review
            {
                Comment = reviewDto.Comment,
                UserId = reviewDto.UserId,
                HolidayId = reviewDto.HolidayId
            };

            context.Reviews.Add(review);
            await context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            var review = await context.Reviews.FindAsync(reviewId);

            if (review == null)
            {
                throw new ArgumentException("Review not found");
            }

            context.Reviews.Remove(review);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByUserIdAsync(Guid userId)
        {
            return await context.Reviews
                          .Where(r => r.UserId == userId)
                          .Select(r => new ReviewDto
                          {
                              Id = r.Id,
                              Comment = r.Comment,
                              HolidayId = r.HolidayId,
                          })
                          .ToListAsync();
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByHolidayIdAsync(int holidayId)
        {
            return await context.Reviews
                         .Where(r => r.HolidayId == holidayId)
                         .Select(r => new ReviewDto
                         {
                             Id = r.Id,
                             Comment = r.Comment,
                             UserId = r.UserId,
                             HolidayId = holidayId
                         })
                         .ToListAsync();
        }

        public async Task UpdateReviewAsync(ReviewDto reviewDto)
        {
            var review = await context.Reviews.FindAsync(reviewDto.Id);

            if (review == null)
            {
                throw new ArgumentException("Review not found");
            }

            review.Comment = reviewDto.Comment;

            context.Reviews.Update(review);
            await context.SaveChangesAsync();
        }
    }
}
