using RickAndMortyApi.Dtos.Comment;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.CommentService
{
    public interface ICommentService
    {
        public Task<ServiceResponse<GetCommentDto>> GetCommentById(int id);
        //public Task<ServiceResponse<List<GetCommentDto>>> GetCommentsByFilter(int amount, int page, CommentParameters parameters);
        public Task<ServiceResponse<GetCommentDto>> AddComment(AddCommentDto newComment);
        public Task<ServiceResponse<GetCommentDto>> UpdateComment(UpdateCommentDto updatedComment);
    }
}
