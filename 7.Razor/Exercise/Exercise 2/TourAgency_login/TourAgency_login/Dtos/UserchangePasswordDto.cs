namespace TourConsultant_login.Dtos
{
    public class UserChangePasswordDto
    {
        public string UserName { get; set; } = null!;
        public string CurrentPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}
