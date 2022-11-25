using RickAndMortyApi.Dtos.Profile;

namespace RickAndMortyApi.Dtos.List
{
    public class GetListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }

        public GetProfileDto? Owner { get; set; }
    }
}
