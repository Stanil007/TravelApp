using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Infrastructure.Data.Entities
{
    public class Amenity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        public List<Holiday> Holidays { get; set; } = new List<Holiday>();
    }
}
