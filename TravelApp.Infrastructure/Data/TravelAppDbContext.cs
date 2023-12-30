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

            // Seed Bookings
            builder.Entity<Booking>().HasData(
                new Booking { Id = 1, UserId = Guid.Parse("0B1CA85C-6D66-4A76-B583-7723302E8542"), HolidayId = 1, DateBooked = DateTime.Now },
                new Booking { Id = 2, UserId = Guid.Parse("C5766467-AFBF-4E85-930C-871A2169959C"), HolidayId = 2, DateBooked = DateTime.Now },
                new Booking { Id = 3, UserId = Guid.Parse("C6649427-B81A-4DD3-8793-D1A7D3F1424D"), HolidayId = 3, DateBooked = DateTime.Now },
                new Booking { Id = 4, UserId = Guid.Parse("A04C6D0D-9E0F-4FA2-A7F6-4D61CF154C37"), HolidayId = 4, DateBooked = DateTime.Now },
                new Booking { Id = 5, UserId = Guid.Parse("9F17E229-A27E-4D05-BEEE-A2882CD42E18"), HolidayId = 5, DateBooked = DateTime.Now }
            );


            //// Seed Reviews
            //builder.Entity<Review>().HasData(
            //    new Review { Id = 1, UserId = /* Use one of the ApplicationUser Ids */, HolidayId = /* Use one of the Holiday Ids */, Comment = "Great experience!" },
            //    new Review { Id = 2, UserId = /* Use one of the ApplicationUser Ids */, HolidayId = /* Use one of the Holiday Ids */, Comment = "Amazing views!" },
            //    new Review { Id = 3, UserId = /* Use one of the ApplicationUser Ids */, HolidayId = /* Use one of the Holiday Ids */, Comment = "Highly recommended!" },
            //    new Review { Id = 4, UserId = /* Use one of the ApplicationUser Ids */, HolidayId = /* Use one of the Holiday Ids */, Comment = "Fantastic getaway!" },
            //    new Review { Id = 5, UserId = /* Use one of the ApplicationUser Ids */, HolidayId = /* Use one of the Holiday Ids */, Comment = "Will definitely come back!" }
            //);



            base.OnModelCreating(builder);
        }
    }
}
