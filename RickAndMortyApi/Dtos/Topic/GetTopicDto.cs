namespace RickAndMortyApi.Dtos.Topic
{
    public class GetTopicDto<T>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public T? RelatedElement { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
