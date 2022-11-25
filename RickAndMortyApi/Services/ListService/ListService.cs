using AutoMapper;
using RickAndMortyApi.Dtos.List;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.ListService
{
    public class ListService : IListService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ListService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<GetListDto>> GetListById(int id)
        {
            ServiceResponse<GetListDto> response = new ServiceResponse<GetListDto>();

            var list = await _context.Lists.Include(l => l.Owner).Where(l => l.Id == id).FirstOrDefaultAsync();

            if (list == null)
            {
                response.Success = false;
                response.Message = "List not found.";
                return response;
            }

            GetListDto listDto = _mapper.Map<GetListDto>(list);

            response.Data = listDto;

            return response;
        }
    }
}
