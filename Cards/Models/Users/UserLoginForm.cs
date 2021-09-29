using System.ComponentModel.DataAnnotations;

namespace Cards.Models.Users
{

    public class UserLoginForm
    {
        [Required]
        public string Name { get; init; }


        [Required]
        public string Password { get; init; }
    }
}
