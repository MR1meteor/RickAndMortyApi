using Rick;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.EpisodeService
{
    public interface IEpisodeService
    {
        public Task<ServiceResponse<Multiple<Episode>>> GetAllEpisodes(int page);
        public Task<ServiceResponse<Episode>> GetEpisode(int id);
        public Task<ServiceResponse<Multiple<Episode>>> GetEpisodes(int page, EpisodeParameters parameters);
    }
}
