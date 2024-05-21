using Microsoft.AspNetCore.Identity;
namespace Core.Dots
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
    }
}
