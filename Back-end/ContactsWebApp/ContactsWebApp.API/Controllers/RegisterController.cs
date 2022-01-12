using AutoMapper;
using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.Shared.Dto;
using ContactsWebApp.Shared.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IValidator<RegisterRequestDto> _validator;
        private readonly IMapper _mapper;

        public RegisterController(IUserService service, IValidator<RegisterRequestDto> validator, IMapper mapper)
        {
            _service = service;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateNewUser([FromBody] RegisterRequestDto request)
        {
            if (_service.UserExists(request.Email))
                return StatusCode(StatusCodes.Status409Conflict);

            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest();

            var user = _mapper.Map<User>(request);
            _service.CreateNewUser(user);

            var response = _mapper.Map<RegisterResponseDto>(user);
            return Created(nameof(CreateNewUser), response);
        }
    }
}
