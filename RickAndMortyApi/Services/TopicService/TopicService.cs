using AutoMapper;
using Rick;
using RickAndMortyApi.Dtos.Topic;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services.CharacterService;
using RickAndMortyApi.Services.EpisodeService;
using RickAndMortyApi.Services.LocationService;
using System.Security.Claims;

namespace RickAndMortyApi.Services.TopicService
{
    public class TopicService : ITopicService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICharacterService _characterService;
        private readonly ILocationService _locationService;
        private readonly IEpisodeService _episodeService;

        public TopicService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor, 
            ICharacterService characterService, ILocationService locationService, IEpisodeService episodeService)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _characterService = characterService;
            _locationService = locationService;
            _episodeService = episodeService;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<GetTopicDto<object>>> GetTopicById(int id)
        {
            ServiceResponse<GetTopicDto<object>> response = new ServiceResponse<GetTopicDto<object>>();

            var topic = await _context.Topics.Where(t => t.Id == id).FirstOrDefaultAsync();

            GetTopicDto<object> topicDto = _mapper.Map<GetTopicDto<object>>(topic);

            if (topic == null)
            {
                response.Success = false;
                response.Message = "Topic not found.";
                return response;
            }

            switch (topic.RelatedElementType)
            {
                case ObjectsType.Character:
                    topicDto.RelatedElement = _characterService.GetCharacter(topic.RelatedElementId);
                    break;
                case ObjectsType.Location:
                    topicDto.RelatedElement = _locationService.GetLocation(topic.RelatedElementId);
                    break;
                case ObjectsType.Episode:
                    topicDto.RelatedElement = _episodeService.GetEpisode(topic.RelatedElementId);
                    break;
                default:
                    break;
            }

            response.Data = topicDto;

            return response;
        }
    }
}
