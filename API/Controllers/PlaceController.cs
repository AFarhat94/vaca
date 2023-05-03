using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PlaceController : BaseController
    {

        private readonly IPlaceService _service;
        public PlaceController(IPlaceService service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IReadOnlyList<Place>>> GetAllPlaces()
        {
            var places = await _service.GetAllAsync();
            return Ok(places);
        }
    }
}