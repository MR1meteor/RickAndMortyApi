namespace RickAndMortyApi.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string Nickname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
