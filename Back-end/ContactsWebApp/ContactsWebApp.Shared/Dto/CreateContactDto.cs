namespace ContactsWebApp.Shared.Dto
{
    public class CreateContactDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
