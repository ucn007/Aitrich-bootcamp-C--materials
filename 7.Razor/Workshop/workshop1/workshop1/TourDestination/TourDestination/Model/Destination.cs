using System.ComponentModel.DataAnnotations;

namespace TourDestination.Model
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Display(Name = "Destination Image")]
        public string? ImagePath { get; set; }
    }
}
