using Microsoft.AspNetCore.Identity;

namespace TravelApp.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
