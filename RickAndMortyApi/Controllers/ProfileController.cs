using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMortyApi.Dtos.Profile;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services.ProfileService;

namespace RickAndMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProfileDto>>> GetProfileById(int id)
        {
            ServiceResponse<GetProfileDto> response = await _profileService.GetProfileById(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult<ServiceResponse<GetProfileDto>>> UpdateProfile(UpdateProfileDto updatedProfile)
        {
            ServiceResponse<GetProfileDto> response = await _profileService.UpdateProfile(updatedProfile);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
