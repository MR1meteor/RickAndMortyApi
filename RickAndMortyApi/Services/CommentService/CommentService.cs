using System.Linq;
using AutoMapper;
using RickAndMortyApi.Dtos.Comment;
using RickAndMortyApi.Models;
using System.Security.Claims;

namespace RickAndMortyApi.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<GetCommentDto>> AddComment(AddCommentDto newComment)
        {
            ServiceResponse<GetCommentDto> response = new ServiceResponse<GetCommentDto>();

            Comment comment = _mapper.Map<Comment>(newComment);
            comment.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            comment.CreateDate = DateTime.Now;
            comment.UpdateDate = comment.CreateDate;

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            response.Data = await _context.Comments.Where(c => c.Id == comment.Id).Select(c => _mapper.Map<GetCommentDto>(c)).FirstOrDefaultAsync();

            return response;
        }

        public async Task<ServiceResponse<GetCommentDto>> UpdateComment(UpdateCommentDto updatedComment)
        {
            ServiceResponse<GetCommentDto> response = new ServiceResponse<GetCommentDto>();

            var comment = await _context.Comments.Include(c => c.User).FirstOrDefaultAsync(c => c.Id.Equals(updatedComment.Id));

            if (comment == null)
            {
                response.Success = false;
                response.Message = "Comment not found.";
                return response;
            }

            if (comment.User == null || comment.User.Id != GetUserId())
            {
                response.Success = false;
                response.Message = "Access denied.";
                return response;
            }

            comment.Text = updatedComment.Text;
            
            await _context.SaveChangesAsync();

            response.Data = await _context.Comments.Where(c => c.Id == comment.Id).Select(c => _mapper.Map<GetCommentDto>(c)).FirstOrDefaultAsync();

            return response;
        }
    }
}
