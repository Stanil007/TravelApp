using System.ComponentModel.DataAnnotations;

namespace TravelApp.Core.DTOModels
{
    public class HolidayDto
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Destination { get; set; }

        public string? Description { get; set; }

        [Required]
        [MaxLength(2048)]
        public string ImageUrl { get; set; }

        public IEnumerable<int> selectedAmenities { get; set; }

        public IEnumerable<ReviewDto> Reviews { get; set; }

        public IEnumerable<BookingDto> Bookings { get; set; }
    }
}
