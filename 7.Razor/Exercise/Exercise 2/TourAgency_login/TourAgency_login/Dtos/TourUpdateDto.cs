using System.ComponentModel.DataAnnotations;

namespace TourConsultant_login.Dtos
{
    public class TourUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tour Name is required")]
        [MaxLength(100)]
        public string TourName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? TourDescription { get; set; }

        [Range(1, 30)]
        public int? NoOfNights { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        public DateOnly? DepartureDate { get; set; }
        public DateOnly? ArrivalDate { get; set; }

    
        [Required(ErrorMessage = "Destination is required")]
        public Guid DestinationId { get; set; }
    }
}
