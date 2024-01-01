using System.ComponentModel.DataAnnotations;

namespace TravelApp.Core.DTOModels
{
    public class BookingDto
    {
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int HolidayId { get; set; }

        [Required]
        public DateTime DateBooked { get; set; }
    }
}
