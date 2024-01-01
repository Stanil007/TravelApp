using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TravelApp.Infrastructure.Data.Entities;

namespace TravelApp.Infrastructure.Data
{
    public class TravelAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>,Guid>
    {

        public TravelAppDbContext(DbContextOptions<TravelAppDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Amenity> Amenities { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Booking>()
                .HasOne(b => b.Holiday)
                .WithMany(h => h.Bookings)
                .HasForeignKey(b => b.HolidayId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Review>()
                .HasOne(r => r.Holiday)
                .WithMany(h => h.Reviews)
                .HasForeignKey(r => r.HolidayId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Holiday>()
                .HasOne(h => h.Category)
                .WithMany(c => c.Holidays)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Holiday>()
                .HasMany(h => h.Amenities)
                .WithMany(a => a.Holidays)
                .UsingEntity(j => j.ToTable("HolidayAmenities"));


            base.OnModelCreating(builder);
        }
    }
}
