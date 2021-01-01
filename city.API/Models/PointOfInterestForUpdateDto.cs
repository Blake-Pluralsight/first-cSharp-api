using System;
using System.ComponentModel.DataAnnotations;

namespace city.API.Models
{
    public class PointOfInterestForUpdateDTO
    {
        [Required(ErrorMessage = "A valid name is required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
