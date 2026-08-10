using System.ComponentModel.DataAnnotations;

namespace TourConsultant_login.Dtos
{
    public class TourRegisterDto
    {
        [Required(ErrorMessage = "Tour Name is required")]
        [MaxLength(100)]
        public string TourName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? TourDescription { get; set; }

        [Range(1, 30, ErrorMessage = "Nights must be between 1 and 30")]
        public int? NoOfNights { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be positive")]
        public int Price { get; set; }

        public DateOnly? DepartureDate { get; set; }
        public DateOnly? ArrivalDate { get; set; }

      
        public Guid DestinationId { get; set; }
    }
}
