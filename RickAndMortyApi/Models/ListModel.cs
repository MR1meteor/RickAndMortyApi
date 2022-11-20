namespace RickAndMortyApi.Models
{
    public class ListModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ObjectsType ObjectsType { get; set; }

        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }

        public int OwnerId { get; set; }
        public UserProfile? Owner { get; set; }
    }
}
