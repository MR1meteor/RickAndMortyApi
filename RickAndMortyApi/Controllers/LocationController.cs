using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rick;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services.LocationService;

namespace RickAndMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("all/{page}")]
        public async Task<ActionResult<ServiceResponse<Multiple<Location>>>> GetAll(int page = 1)
        {
            var response = await _locationService.GetAllLocations(page);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Location>>> GetById(int id)
        {
            var response = await _locationService.GetLocation(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Multiple<Location>>>> GetByFilter([FromQuery] LocationParameters parameters, int page = 1)
        {
            var response = await _locationService.GetLocations(page, parameters);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
