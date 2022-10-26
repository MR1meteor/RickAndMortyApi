using RickAndMortyApi.Dtos.Comment;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.CommentService
{
    public interface ICommentService
    {
        public Task<ServiceResponse<GetCommentDto>> AddComment(AddCommentDto newComment);
    }
}
