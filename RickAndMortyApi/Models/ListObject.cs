namespace RickAndMortyApi.Models
{
    public class ListObject
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public int ListId { get; set; }
        public ListModel? List { get; set; }
        public int RelatedElementId { get; set; }
        public ObjectsType RelatedElementType { get; set; }

        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
