using RickAndMortyApi.Dtos.ListObject;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.ListObjectService
{
    public interface IListObjectService
    {
        public Task<ServiceResponse<GetListObjectDto<object>>> GetListObjectById(int id);
    }
}
