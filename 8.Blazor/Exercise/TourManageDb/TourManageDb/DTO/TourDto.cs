using System.ComponentModel.DataAnnotations;
using TourManageDb.Model;

namespace TourManageDb.DTO
{
    public class TourDto
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
    }
}
