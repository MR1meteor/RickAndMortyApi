using RickAndMortyApi.Models;

namespace RickAndMortyApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ListModel> Lists { get; set; }
        public DbSet<ListObject> ListObjects { get; set; }
    }
}
