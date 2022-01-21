using AutoMapper;
using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.Shared.Dto;
using ContactsWebApp.Shared.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsWebApp.API.Controllers
{
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactService _service;
        private readonly IValidator<CreateContactDto> _validatorCreate;
        private readonly IValidator<UpdateContactDto> _validatorUpdate;

        public ContactsController(IMapper mapper, IContactService service, IValidator<CreateContactDto> validatorCreate,
            IValidator<UpdateContactDto> validatorUpdate)
        {
            _mapper = mapper;
            _service = service;
            _validatorCreate = validatorCreate;
            _validatorUpdate = validatorUpdate;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewContact(int userId, [FromBody] CreateContactDto request)
        {
            var validationResult = _validatorCreate.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest();

            var contact = _mapper.Map<Contact>(request);
            await _service.CreateNewContactAsync(userId, contact);

            var contactDto = _mapper.Map<ContactDto>(contact);
            return Created(nameof(CreateNewContact), contactDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContacts(int userId)
        {
            var contacts = await _service.FindContactsByUserIdAsync(userId);
            var response = _mapper.Map<IEnumerable<ContactDto>>(contacts);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, int userId, [FromBody] UpdateContactDto request)
        {
            if (!await _service.ContactExistsAsync(id))
                return NotFound();

            var validationResult = _validatorUpdate.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest();

            var contact = _mapper.Map<Contact>(request);
            await _service.UpdateContactAsync(id, userId, contact);

            var contactDto = _mapper.Map<ContactDto>(contact);
            return Ok(contactDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _service.FindContactByIdAsync(id);
            await _service.DeleteContactAsync(contact);

            return Ok();
        }
    }
}
