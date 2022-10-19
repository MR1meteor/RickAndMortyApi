using Rick;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<Multiple<Character>>> GetAllCharacters(int page);
        Task<ServiceResponse<Character>> GetCharacter(int id);
        Task<ServiceResponse<Multiple<Character>>> GetCharacter(int page, CharacterParameters parameters);
    }
}
