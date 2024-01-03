using System.ComponentModel.DataAnnotations;

namespace TravelApp.Core.DTOModels
{   public class ReviewDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Comment { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int HolidayId { get; set; }
    }
}
