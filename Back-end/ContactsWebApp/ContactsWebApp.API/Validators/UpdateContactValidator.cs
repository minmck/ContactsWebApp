using ContactsWebApp.Shared.Dto;
using FluentValidation;

namespace ContactsWebApp.API.Validators
{
    public class UpdateContactValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().NotNull();
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
