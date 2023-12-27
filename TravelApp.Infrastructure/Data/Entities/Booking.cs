using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Infrastructure.Data.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        [Required]
        public Guid UserId { get; set; }


        [Required]
        [ForeignKey(nameof(HolidayId))]
        public Holiday Holiday { get; set; }

        [Required]
        public int HolidayId { get; set; }

        [Required]
        public DateTime DateBooked { get; set; }
    }
}
