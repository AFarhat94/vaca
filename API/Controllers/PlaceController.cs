using System.Security.Claims;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PlaceController : BaseController
    {

        private readonly IPlaceService _service;
        private readonly UserManager<AppUser> _userManager;
        public PlaceController(IPlaceService service, UserManager<AppUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("getAll")]
        public async Task<ActionResult<IReadOnlyList<Place>>> GetAllPlacesByUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            var user = await _userManager.FindByEmailAsync(email);

            var places = await _service.GetAllByUserAsync(user);
            return Ok(places);
        }

        [Authorize]
        [HttpPost("save")]
        public async Task<ActionResult> Save(Place place)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            var user = await _userManager.FindByEmailAsync(email);
            place.UserId = user.Id;
            await _service.AddAsync(place);
            return Ok();
        }
    }
}