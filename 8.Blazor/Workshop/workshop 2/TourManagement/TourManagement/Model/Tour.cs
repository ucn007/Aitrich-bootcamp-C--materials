namespace TourManagement.Model
{
    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DestinationId { get; set; }
        public Destination TDestination { get; set; }
        //public object Destination { get; internal set; }
    }
}
