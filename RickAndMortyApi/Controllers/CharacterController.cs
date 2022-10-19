using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rick;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services;

namespace RickAndMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("all/{page}")]
        public async Task<ActionResult<ServiceResponse<Multiple<Character>>>> GetAll(int page = 1)
        {
            var response = await _characterService.GetAllCharacters(page);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetById(int id)
        {
            var response = await _characterService.GetCharacter(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Multiple<Character>>>> GetByFilter([FromQuery] CharacterParameters parameters, int page = 1)
        {
            var response = await _characterService.GetCharacter(page, parameters);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
