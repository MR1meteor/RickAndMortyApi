namespace RickAndMortyApi.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        //public T? RelatedElement { get; set; }
        public int RelatedElementId { get; set; }
        public ObjectsType RelatedElementType { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }

        public UserProfile? Owner { get; set; }
    }
}
