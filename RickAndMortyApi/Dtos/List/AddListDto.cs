using RickAndMortyApi.Models;

namespace RickAndMortyApi.Dtos.List
{
    public class AddListDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ObjectsType ObjectsType { get; set; } = ObjectsType.Character;
    }
}
