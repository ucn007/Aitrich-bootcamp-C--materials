using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TourDestination.Dtos                                                                                                                
{
    public class DestinationcreationDto
    {

        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string City { get; set; } = string.Empty;

        // File upload field for the image
        [Display(Name = "Upload Destination Image")]
        // ✅ Add this property to store image path
        public string? ImagePath { get; set; }

        // For uploading a new image
        public IFormFile? ImageFile { get; set; }
    }
}
