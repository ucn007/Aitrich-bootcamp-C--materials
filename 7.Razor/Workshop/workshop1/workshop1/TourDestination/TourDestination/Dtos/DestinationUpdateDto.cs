using System.ComponentModel.DataAnnotations;

namespace TourDestination.DestinationDto
{
    public class DestinationUpdateDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string? ImagePath { get; set; }   // existing image

        public IFormFile? ImageFile { get; set; }  // new upload
    }
}

