using System.Security.Claims;
using API.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public PlaceController(IPlaceService service, UserManager<AppUser> userManager, IMapper mapper)
        {
            _service = service;
            _userManager = userManager;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("getAll")]
        public async Task<ActionResult<IReadOnlyList<PlaceDTO>>> GetAllPlacesByUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            var user = await _userManager.FindByEmailAsync(email);

            var places = await _service.GetAllByUserAsync(user);
            var placesDTO = places.Select(place => 
                _mapper.Map<PlaceDTO>(place)
            );

            return Ok(placesDTO);
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