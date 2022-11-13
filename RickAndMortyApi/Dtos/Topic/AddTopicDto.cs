using RickAndMortyApi.Models;

namespace RickAndMortyApi.Dtos.Topic
{
    public class AddTopicDto
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int RelatedElementId { get; set; } = 0;
        public ObjectsType RelatedElementType { get; set; } = ObjectsType.Character;
    }
}
