using System.ComponentModel.DataAnnotations;

namespace TravelApp.Infrastructure.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Holiday> Holidays { get; set; } = new List<Holiday>();
    }
}
