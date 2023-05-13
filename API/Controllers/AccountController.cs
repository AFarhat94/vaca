using System.Security.Claims;
using API.Dtos.Identity;
using Core.Entities.Identity;
using Core.Interfaces.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _token;
        public AccountController(UserManager<AppUser> userManger, 
            SignInManager<AppUser> signInManager,
            ITokenService token)
        {
            _userManager = userManger;
            _signInManager = signInManager;
            _token = token;
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var email = HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);

            return Ok(new UserDTO()
            {
                Email = user.Email,
                GivenName = user.GivenName,
                Name = user.Name,
                Token = _token.CreateToken(user)
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded) return BadRequest();

            return Ok(new UserDTO()
            {
                Email = user.Email,
                GivenName = user.GivenName,
                Name = user.Name,
                Token = _token.CreateToken(user)
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO register)
        {
            var user = new AppUser()
            {
                Email = register.Email,
                GivenName = register.GivenName,
                Name = register.Name,
                UserName = register.Email
            };

            var create = await _userManager.CreateAsync(user, register.Password);
            if (!create.Succeeded) return BadRequest(create.Errors);

            return Ok(new UserDTO(){
                Email = user.Email,
                GivenName = user.GivenName,
                Name = user.Name,
                Token = _token.CreateToken(user)
            });
        }
    }
}