using Rick;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.LocationService
{
    public interface ILocationService
    {
        public Task<ServiceResponse<Multiple<Location>>> GetAllLocations(int page);
        public Task<ServiceResponse<Location>> GetLocation(int id);
        public Task<ServiceResponse<Multiple<Location>>> GetLocations(int page, LocationParameters parameters);
    }
}
