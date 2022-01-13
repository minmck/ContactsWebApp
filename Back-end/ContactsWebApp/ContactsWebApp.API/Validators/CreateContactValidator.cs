using ContactsWebApp.Shared.Dto;
using FluentValidation;

namespace ContactsWebApp.API.Validators
{
    public class CreateContactValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.FullName).NotEmpty().NotNull();
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
