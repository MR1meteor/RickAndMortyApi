namespace RickAndMortyApi.Dtos.Topic
{
    public class UpdateTopicDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
