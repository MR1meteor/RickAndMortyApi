using Rick;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.LocationService
{
    public class LocationService : ILocationService
    {
        public async Task<ServiceResponse<Multiple<Location>>> GetAllLocations(int page)
        {
            ServiceResponse<Multiple<Location>> response = new ServiceResponse<Multiple<Location>>();

            Multiple<Location> locations = await Search.GetAllLocationsAsync(page);

            if (locations.DidError)
            {
                response.Success = false;
                response.Message = "Locations not found";
                return response;
            }

            response.Data = locations;

            return response;
        }

        public async Task<ServiceResponse<Location>> GetLocation(int id)
        {
            ServiceResponse<Location> response = new ServiceResponse<Location>();

            Location location = await Search.GetLocationAsync(id);

            if (location.DidError)
            {
                response.Success = false;
                response.Message = "Location not found";
                return response;
            }

            response.Data = location;

            return response;
        }

        public async Task<ServiceResponse<Multiple<Location>>> GetLocations(int page, LocationParameters parameters)
        {
            ServiceResponse<Multiple<Location>> response = new ServiceResponse<Multiple<Location>>();

            Multiple<Location> locations = await Search.GetLocationAsync(page, parameters.Name, parameters.Type, parameters.Dimention);

            if (locations.DidError)
            {
                response.Success = false;
                response.Message = "Location(s) not found";
                return response;
            }

            response.Data = locations;

            return response;
        }
    }
}
