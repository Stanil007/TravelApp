using System.ComponentModel.DataAnnotations;

namespace TravelApp.Core.DTOModels
{
    public class AmenityDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
