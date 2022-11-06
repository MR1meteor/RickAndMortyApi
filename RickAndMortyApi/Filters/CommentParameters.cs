using RickAndMortyApi.Models;

namespace RickAndMortyApi.Filters
{
    public class CommentParameters
    {
        public int? UserId { get; set; } = null;
        public int? ParentId { get; set; } = null;
        public CommentType? Type { get; set; } = null;
        public int? RelatedElementId { get; set; } = null;
    }
}
