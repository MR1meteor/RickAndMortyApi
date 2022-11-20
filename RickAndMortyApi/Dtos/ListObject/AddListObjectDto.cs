using RickAndMortyApi.Models;

namespace RickAndMortyApi.Dtos.ListObject
{
    public class AddListObjectDto
    {
        public string Text { get; set; } = string.Empty;
        public int ListId { get; set; } = 0;
        public int RelatedElementId { get; set; } = 0;
        public ObjectsType RelatedElementType { get; set; } = ObjectsType.Character;
    }
}
