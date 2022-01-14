using AutoMapper;
using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.Shared.Dto;
using ContactsWebApp.Shared.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        private readonly IValidator<UpdateContactDto> _validatorUpdate;

        public ContactsController(IMapper mapper, IContactService service, IValidator<CreateContactDto> validatorCreate, IValidator<UpdateContactDto> validatorUpdate)
        {
            _mapper = mapper;
            _service = service;
            _validatorCreate = validatorCreate;
            _validatorUpdate = validatorUpdate;
        }

        [HttpPost]
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

        [HttpGet]
        public ActionResult<IEnumerable<ContactDto>> GetContactsByUserId(int userId)
        {
            if (!_service.ContactsExist(userId))
                return NotFound();

            var contacts = _service.FindContactsByUserId(userId);
            var response = _mapper.Map<IEnumerable<ContactDto>>(contacts);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateContact([FromBody] UpdateContactDto request)
        {
            if (!_service.ContactExists(request.Id))
                return NotFound();

            var validationResult = _validatorUpdate.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest();

            var contact = _mapper.Map<Contact>(request);
            _service.UpdateContact(contact);

            var contactDto = _mapper.Map<ContactDto>(contact);
            return Ok(contactDto);
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _service.FindContactById(id);
            _service.DeleteContact(contact);

            return Ok();
        }
    }
}
