using System.ComponentModel.DataAnnotations;

namespace Destination.Model
{
    public class Tour
    {
        [Key]
        public Guid Id { get; set; }   // UID instead of int

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        public string? Destination { get; set; }

        [Range(1, 100, ErrorMessage = "Nights must be at least 1")]
        public int Nights { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Departure date is required")]
        public DateTime? DepartureDate { get; set; }

        public DateTime? ArrivalDate { get; set; }
    }
}