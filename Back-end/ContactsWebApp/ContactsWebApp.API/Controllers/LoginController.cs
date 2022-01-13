using AutoMapper;
using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _serviceUser;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _serviceAuthenticate;

        public LoginController(IUserService service, IMapper mapper, IAuthenticationService serviceAuthenticate)
        {
            _serviceUser = service;
            _mapper = mapper;
            _serviceAuthenticate = serviceAuthenticate;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            if (!_serviceUser.UserValid(request.Email, request.Password))
                return Unauthorized();

            var user = _serviceUser.FindUserByEmail(request.Email);
            var response = _mapper.Map<LoginResponseDto>(user);

            response.Token = _serviceAuthenticate.GenerateJwtToken(user);
            return Ok(response);
        }
    }
}
