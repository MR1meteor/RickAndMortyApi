using Rick;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<Multiple<Character>>> GetAllCharacters(int page);
        Task<ServiceResponse<Character>> GetCharacter(int id);
        Task<ServiceResponse<Multiple<Character>>> GetCharacters(int page, CharacterParameters parameters);
    }
}
