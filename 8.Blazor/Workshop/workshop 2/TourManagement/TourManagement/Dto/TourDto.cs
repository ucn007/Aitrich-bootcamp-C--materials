namespace TourManagement.Dto
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
    }
}
