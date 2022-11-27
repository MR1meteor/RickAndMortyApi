using RickAndMortyApi.Dtos.Profile;
using RickAndMortyApi.Dtos.Topic;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Dtos.Comment
{
    public class GetCommentDto
    {
        /*
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public CommentType Type { get; set; } = CommentType.Character;
        public int RelatedElementId { get; set; }
        */
        public int Id { get; set; }
        public GetTopicDto<object>? Topic { get; set; }
        public string Text { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public List<GetCommentDto>? Childrens { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public GetProfileDto? User { get; set; }
    }
}
