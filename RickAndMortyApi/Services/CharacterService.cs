using Rick;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services
{
    public class CharacterService : ICharacterService
    {
        public async Task<ServiceResponse<Multiple<Character>>> GetAllCharacters(int page)
        {
            ServiceResponse<Multiple<Character>> response = new ServiceResponse<Multiple<Character>>();

            Multiple<Character> characters = await Search.GetAllCharactersAsync(page);

            if (characters.DidError)
            {
                response.Success = false;
                response.Message = "Characters not found";
                return response;
            }

            response.Data = characters;
          
            return response;
        }

        public async Task<ServiceResponse<Character>> GetCharacter(int id)
        {
            ServiceResponse<Character> response = new ServiceResponse<Character>();

            Character character = await Search.GetCharacterAsync(id);

            if (character.DidError)
            {
                response.Success = false;
                response.Message = "Character not found";
                return response;
            }

            response.Data = character;
            return response;
        }

        public async Task<ServiceResponse<Multiple<Character>>> GetCharacter(int page, CharacterParameters parameters)
        {
            ServiceResponse<Multiple<Character>> response = new ServiceResponse<Multiple<Character>>();

            Multiple<Character> characters = await Search.GetCharacterAsync(page, parameters.Name, parameters.Status, parameters.Species, parameters.Type, parameters.Gender);

            if (characters.DidError)
            {
                response.Success = false;
                response.Message = "Character(s) not found";
                return response;
            }

            response.Data = characters;

            return response;
        }
    }
}
