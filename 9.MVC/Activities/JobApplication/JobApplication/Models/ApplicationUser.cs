using Microsoft.AspNetCore.Identity;

namespace JobApplication.Models;

public class ApplicationUser:IdentityUser
{
    public Guid? CompId { get; set; }

    public virtual Company? Comp { get; set; }
}