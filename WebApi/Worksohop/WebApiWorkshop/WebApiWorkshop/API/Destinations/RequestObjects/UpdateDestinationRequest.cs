namespace WebApiWorkshop.API.Destinations.RequestObjects
{
    public class UpdateDestinationRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
