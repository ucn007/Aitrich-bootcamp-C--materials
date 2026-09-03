namespace Destination.Dto
{
    public class TourDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Destination { get; set; }
        public int Nights { get; set; }
        public decimal Price { get; set; }
        public DateTime? DepartureDate { get; set; }

        public DateTime? ArrivalDate { get; set; }

    }
}