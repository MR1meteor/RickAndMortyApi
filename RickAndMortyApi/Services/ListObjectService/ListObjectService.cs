using AutoMapper;
using RickAndMortyApi.Dtos.ListObject;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services.CharacterService;
using RickAndMortyApi.Services.EpisodeService;
using RickAndMortyApi.Services.LocationService;
using System.Security.Claims;

namespace RickAndMortyApi.Services.ListObjectService
{
    public class ListObjectService : IListObjectService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICharacterService _characterService;
        private readonly ILocationService _locationService;
        private readonly IEpisodeService _episodeService;

        public ListObjectService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor,
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

        public async Task<ServiceResponse<GetListObjectDto<object>>> GetListObjectById(int id)
        {
            ServiceResponse<GetListObjectDto<object>> response = new ServiceResponse<GetListObjectDto<object>>();

            var listObject = await _context.ListObjects.Include(o => o.List).Where(o => o.Id == id).FirstOrDefaultAsync();

            GetListObjectDto<object> objectDto = _mapper.Map<GetListObjectDto<object>>(listObject);

            if (listObject == null)
            {
                response.Success = false;
                response.Message = "Element not found.";
                return response;
            }

            switch (listObject.RelatedElementType)
            {
                case ObjectsType.Character:
                    objectDto.RelatedElement = await _characterService.GetCharacter(listObject.RelatedElementId);
                    break;
                case ObjectsType.Location:
                    objectDto.RelatedElement = await _locationService.GetLocation(listObject.RelatedElementId);
                    break;
                case ObjectsType.Episode:
                    objectDto.RelatedElement = await _episodeService.GetEpisode(listObject.RelatedElementId);
                    break;
                default:
                    break;
            }

            response.Data = objectDto;

            return response;
        }
    }
}
