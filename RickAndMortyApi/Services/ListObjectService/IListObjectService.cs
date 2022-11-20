using RickAndMortyApi.Dtos.ListObject;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.ListObjectService
{
    public interface IListObjectService
    {
        public Task<ServiceResponse<GetListObjectDto<object>>> GetListObjectById(int id);
        public Task<ServiceResponse<GetListObjectDto<object>>> AddListObject(AddListObjectDto newObject);
        public Task<ServiceResponse<GetListObjectDto<object>>> UpdateListObject(UpdateListObjectDto updatedObject);
    }
}
