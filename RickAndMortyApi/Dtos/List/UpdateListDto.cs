namespace RickAndMortyApi.Dtos.List
{
    public class UpdateListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
