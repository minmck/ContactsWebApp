using AutoMapper;
using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _serviceUser;
        private readonly IMapper _mapper;

        public LoginController(IUserService service, IMapper mapper)
        {
            _serviceUser = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            if (!_serviceUser.UserValid(request.Email, request.Password))
                return Unauthorized();

            var user = _serviceUser.FindUserByEmail(request.Email);
            var response = _mapper.Map<LoginResponseDto>(user);

            return Ok(response);
        }
    }
}
