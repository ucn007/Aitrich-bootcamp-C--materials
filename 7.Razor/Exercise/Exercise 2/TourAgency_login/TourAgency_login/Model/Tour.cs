using System.ComponentModel.DataAnnotations;

namespace TourConsultant_login.Model
{
    public class Tour
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string TourName { get; set; } = string.Empty;

        public string? TourDescription { get; set; }

        [Required]
        public Guid DestinationId { get; set; }

        public Destination Destination { get; set; }   // Navigation property

        public int? NoOfNights { get; set; }

        [Required]
        public int Price { get; set; }

        public DateOnly? DepartureDate { get; set; }
        public DateOnly? ArrivalDate { get; set; }
    }
    }

