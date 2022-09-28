using Microsoft.AspNetCore.Identity;

namespace RentAMovie.Models
{
    public class Member : IdentityUser
    {
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; }
        public City City  { get; set; }

    }
}
