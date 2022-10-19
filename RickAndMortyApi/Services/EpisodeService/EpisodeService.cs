using Rick;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.EpisodeService
{
    public class EpisodeService : IEpisodeService
    {
        public async Task<ServiceResponse<Multiple<Episode>>> GetAllEpisodes(int page)
        {
            ServiceResponse<Multiple<Episode>> response = new ServiceResponse<Multiple<Episode>>();

            Multiple<Episode> episodes = await Search.GetAllEpisodesAsync(page);

            if (episodes.DidError)
            {
                response.Success = false;
                response.Message = "Episodes not found";
                return response;
            }

            response.Data = episodes;

            return response;
        }

        public async Task<ServiceResponse<Episode>> GetEpisode(int id)
        {
            ServiceResponse<Episode> response = new ServiceResponse<Episode>();

            Episode episode = await Search.GetEpisodeAsync(id);

            if (episode.DidError)
            {
                response.Success = false;
                response.Message = "Episode not found";
                return response;
            }

            response.Data = episode;

            return response;
        }

        public async Task<ServiceResponse<Multiple<Episode>>> GetEpisodes(int page, EpisodeParameters parameters)
        {
            ServiceResponse<Multiple<Episode>> response = new ServiceResponse<Multiple<Episode>>();

            Multiple<Episode> episodes = await Search.GetEpisodeAsync(page, parameters.Name, parameters.Code);

            if (episodes.DidError)
            {
                response.Success = false;
                response.Message = "Episode(s) not found";
                return response;
            }

            response.Data = episodes;

            return response;
        }
    }
}
