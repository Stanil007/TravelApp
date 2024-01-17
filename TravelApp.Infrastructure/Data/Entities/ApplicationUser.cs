using Microsoft.AspNetCore.Identity;

namespace TravelApp.Infrastructure.Data.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
