using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rick;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services.EpisodeService;

namespace RickAndMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [HttpGet("all/{page}")]
        public async Task<ActionResult<ServiceResponse<Multiple<Episode>>>> GetAll(int page = 1)
        {
            var response = await _episodeService.GetAllEpisodes(page);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Episode>>> GetById(int id)
        {
            var response = await _episodeService.GetEpisode(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Multiple<Episode>>>> GetByFilter([FromQuery] EpisodeParameters parameters, int page = 1)
        {
            var response = await _episodeService.GetEpisodes(page, parameters);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
