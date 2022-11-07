using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMortyApi.Dtos.Topic;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services.TopicService;

namespace RickAndMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("id")]
        public async Task<ActionResult<ServiceResponse<GetTopicDto<object>>>> GetTopicById(int id)
        {
            ServiceResponse<GetTopicDto<object>> response = await _topicService.GetTopicById(id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
