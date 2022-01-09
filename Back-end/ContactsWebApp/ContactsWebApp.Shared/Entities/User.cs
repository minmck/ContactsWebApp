using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsWebApp.Shared.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the first name is 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the last name is 30 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(5, ErrorMessage = "Minimum length for the password is 5 characters.")]
        public string Password { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
