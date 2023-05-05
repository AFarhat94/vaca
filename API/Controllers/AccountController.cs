using API.Dtos.Identity;
using Core.Entities.Identity;
using Core.Interfaces.Identity;
using Infra.Services.Identity;
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
                Token = _token.CreateToken(user)
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO register)
        {
            var user = new AppUser()
            {
                Email = register.Email,
                UserName = register.Email
            };

            var create = await _userManager.CreateAsync(user, register.Password);
            if (!create.Succeeded) return BadRequest(create.Errors);

            return Ok(new UserDTO(){
                Email = user.Email,
                Token = _token.CreateToken(user)
            });
        }
    }
}