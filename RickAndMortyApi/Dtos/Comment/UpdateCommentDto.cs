namespace RickAndMortyApi.Dtos.Comment
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
