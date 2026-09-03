using System.ComponentModel.DataAnnotations;

namespace TourManageDb.Model
{
    public class Tour
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public long Price { get; set; }

        [Required]
        public int DestinationId { get; set; }
        public Destination? Destination { get; set; }
    }
}
