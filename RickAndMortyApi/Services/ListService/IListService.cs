using RickAndMortyApi.Dtos.List;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.ListService
{
    public interface IListService
    {
        public Task<ServiceResponse<GetListDto>> GetListById(int id);
        public Task<ServiceResponse<GetListDto>> AddList(AddListDto newList);
    }
}
