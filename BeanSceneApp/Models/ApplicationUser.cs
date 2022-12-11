using Microsoft.AspNetCore.Identity;

namespace BeanSceneApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public string? ProfileURL { get; set; }
    }
}
