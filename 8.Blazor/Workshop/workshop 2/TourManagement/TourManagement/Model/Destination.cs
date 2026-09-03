namespace TourManagement.Model
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Tour> Tours { get; set; }
    }
}
