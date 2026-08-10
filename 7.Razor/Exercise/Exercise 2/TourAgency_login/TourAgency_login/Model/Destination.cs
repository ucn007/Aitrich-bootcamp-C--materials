namespace TourConsultant_login.Model
{
    public class Destination
    {
        public Guid Id { get; set; }   // changed to Guid

        public string DestinationName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Image { get; set; }

        public Guid RegisterId { get; set; }

    }
}
