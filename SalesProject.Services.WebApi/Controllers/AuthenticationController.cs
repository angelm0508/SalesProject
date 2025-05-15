using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SalesProject.Application.DTO.authentication;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateApplication _authenticateApplication;
        public IConfiguration Configuration { get; }

        public AuthenticationController(IAuthenticateApplication authenticateApplication, IConfiguration configuration)
        {
            _authenticateApplication = authenticateApplication;
            Configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] AuthenticateCreateDTO authenticateDTO)
        {
            var insert  = await _authenticateApplication.RegisterAsync(authenticateDTO);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthenticateDTO authenticateDTO)
        {
            var user = await _authenticateApplication.AuthenticateAsync(authenticateDTO);

            if (!user.IsSuccess)
                return Unauthorized(user);

            return Ok(user);   
        }
    }
}
