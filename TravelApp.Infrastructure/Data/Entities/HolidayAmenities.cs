using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Infrastructure.Data.Entities
{
    public class HolidayAmenities
    {
        [ForeignKey(nameof(Holiday))]
        [Required]
        public int HolidayId { get; set; }

        [Required]
        public Holiday Holiday { get; set; }


        [Required]
        [ForeignKey(nameof(Amenity))]
        public int AmenityId { get; set; }

        [Required]
        public Amenity Amenity { get; set; }
    }
}
