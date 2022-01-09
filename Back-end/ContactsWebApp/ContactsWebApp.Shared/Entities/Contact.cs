using System.ComponentModel.DataAnnotations;

namespace ContactsWebApp.Shared.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the full name is 50 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress]
        public string Email { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
