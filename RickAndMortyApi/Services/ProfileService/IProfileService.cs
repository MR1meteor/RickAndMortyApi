using RickAndMortyApi.Dtos.Profile;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.ProfileService
{
    public interface IProfileService
    {
        Task<ServiceResponse<GetProfileDto>> GetProfileById(int id);
        Task<ServiceResponse<GetProfileDto>> UpdateProfile(UpdateProfileDto updatedProfile);
    }
}
