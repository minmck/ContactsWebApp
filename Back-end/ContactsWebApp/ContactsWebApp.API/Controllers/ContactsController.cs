using AutoMapper;
using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.Shared.Dto;
using ContactsWebApp.Shared.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApp.API.Controllers
{
    [Route("api/users/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactService _service;
        private readonly IValidator<CreateContactDto> _validatorCreate;

        public ContactsController(IMapper mapper, IContactService service, IValidator<CreateContactDto> validatorCreate)
        {
            _mapper = mapper;
            _service = service;
            _validatorCreate = validatorCreate;
        }

        public IActionResult CreateNewContact([FromBody] CreateContactDto request)
        {
            var validationResult = _validatorCreate.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest();

            var contact = _mapper.Map<Contact>(request);
            _service.CreateNewContact(contact);

            var contactDto = _mapper.Map<ContactDto>(contact);
            return Created(nameof(CreateNewContact), contactDto);
        }
    }
}
