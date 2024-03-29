﻿using System.ComponentModel.DataAnnotations;
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
        [MaxLength(50)]
        public string Destination { get; set; }

        public string? Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }


        public List<Amenity> Amenities { get; set; } = new List<Amenity>();

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
