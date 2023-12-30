using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Infrastructure.Data.Entities
{
    public class Holiday
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = default!;

        [Required]
        public string Destination { get; set; }

        public string? Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }


        public ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
