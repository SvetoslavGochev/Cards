namespace Cards.Models.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserFormModel
    {

        [Required]
        public string Name { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }
    }
}
