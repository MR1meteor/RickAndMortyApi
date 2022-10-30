using Rick;

namespace RickAndMortyApi.Dtos.Profile
{
    public class GetProfileDto
    {
        public int Id { get; set; }

        public string Nickname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }

        /*
        public List<Episode> FavoriteEpisodes { get; set; } = new List<Episode>();
        public List<Character> FavoriteCharacters { get; set; } = new List<Character>();
        public List<Location> FavoriteLocations { get; set; } = new List<Location>();
        */
    }
}
