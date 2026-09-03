using System.ComponentModel.DataAnnotations;

namespace TourManageDb.Model
{
    public class Destination
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
