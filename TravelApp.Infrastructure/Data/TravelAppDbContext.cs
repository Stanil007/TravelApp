using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelApp.Infrastructure.Data.Entities;

namespace TravelApp.Infrastructure.Data
{
    public class TravelAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>,Guid>
    {

        public TravelAppDbContext(DbContextOptions<TravelAppDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
