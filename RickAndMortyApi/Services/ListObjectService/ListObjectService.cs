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

            if (listObject == null)
            {
                response.Success = false;
                response.Message = "Element not found.";
                return response;
            }

            GetListObjectDto<object> objectDto = _mapper.Map<GetListObjectDto<object>>(listObject);

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

        public async Task<ServiceResponse<List<GetListObjectDto<object>>>> GetListObjectsByListId(int listId)
        {
            ServiceResponse<List<GetListObjectDto<object>>> response = new ServiceResponse<List<GetListObjectDto<object>>>();

            var listObjects = await _context.ListObjects.Include(o => o.List).Where(o => o.ListId == listId).ToListAsync();

            if (listObjects == null || listObjects.Count == 0)
            {
                response.Success = false;
                response.Message = "Object(s) not found.";
                return response;
            }

            List<GetListObjectDto<object>> objectsDto = _mapper.Map<List<GetListObjectDto<object>>>(listObjects);

            for (int i = 0; i < objectsDto.Count; i++)
            {
                switch (listObjects[i].RelatedElementType)
                {
                    case ObjectsType.Character:
                        objectsDto[i].RelatedElement = await _characterService.GetCharacter(listObjects[i].RelatedElementId);
                        break;
                    case ObjectsType.Location:
                        objectsDto[i].RelatedElement = await _locationService.GetLocation(listObjects[i].RelatedElementId);
                        break;
                    case ObjectsType.Episode:
                        objectsDto[i].RelatedElement = await _episodeService.GetEpisode(listObjects[i].RelatedElementId);
                        break;
                    default:
                        break;
                }
            }

            response.Data = objectsDto;

            return response;
        }

        public async Task<ServiceResponse<GetListObjectDto<object>>> AddListObject(AddListObjectDto newObject)
        {
            ServiceResponse<GetListObjectDto<object>> response = new ServiceResponse<GetListObjectDto<object>>();

            if (newObject.ListId == 0)
            {
                response.Success = false;
                response.Message = "Wrong data";
                return response;
            }

            ListObject listObject = _mapper.Map<ListObject>(newObject);
            listObject.CreateDate = DateTime.Now;
            listObject.UpdateDate = listObject.CreateDate;

            _context.ListObjects.Add(listObject);
            await _context.SaveChangesAsync();

            response.Data = GetListObjectById(listObject.Id).Result.Data;

            return response;
        }

        public async Task<ServiceResponse<GetListObjectDto<object>>> UpdateListObject(UpdateListObjectDto updatedObject)
        {
            ServiceResponse<GetListObjectDto<object>> response = new ServiceResponse<GetListObjectDto<object>>();

            var listObject = await _context.ListObjects.FirstOrDefaultAsync(o => o.Id.Equals(updatedObject.Id));

            if (listObject == null)
            {
                response.Success = false;
                response.Message = "Object not found.";
                return response;
            }

            listObject.Text = updatedObject.Text;

            await _context.SaveChangesAsync();

            response.Data = GetListObjectById(listObject.Id).Result.Data;

            return response;
        }

        
    }
}
