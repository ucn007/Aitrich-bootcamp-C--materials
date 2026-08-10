using System.ComponentModel.DataAnnotations;
using TourConsultant_login.Enum;

namespace TourAgency_login.Model
{
    public  class  User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Gender { get; set; }


        public DateOnly? Dob { get; set; }

        public UserRole Role { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? EmailId { get; set; }

        public string? TelephoneNo { get; set; }
    }
}

