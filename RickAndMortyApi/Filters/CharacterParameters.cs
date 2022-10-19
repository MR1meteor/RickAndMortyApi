using Rick;

namespace RickAndMortyApi.Filters
{
    public class CharacterParameters
    {
        public string Name { get; set; } = string.Empty;
        public Status Status { get; set; }
        public string Species { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Gender Gender { get; set; }
    }
}
