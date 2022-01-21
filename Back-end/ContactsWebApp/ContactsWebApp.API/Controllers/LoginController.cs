using AutoMapper;
using ContactsWebApp.BLL.Interfaces;
using ContactsWebApp.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!await _serviceUser.UserValidAsync(request.Email, request.Password))
                return Unauthorized();

            var user = await _serviceUser.FindUserByEmailAsync(request.Email);
            var response = _mapper.Map<LoginResponseDto>(user);

            response.Token = _serviceAuthenticate.GenerateJwtToken(user);
            return Ok(response);
        }
    }
}
