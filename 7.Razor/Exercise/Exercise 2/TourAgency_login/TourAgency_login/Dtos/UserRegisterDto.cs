namespace TourConsultant_login.Dtos
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Gender { get; set; }
        public DateOnly? Dob { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? EmailId { get; set; }
        public string? TelephoneNo { get; set; }
    }
}
