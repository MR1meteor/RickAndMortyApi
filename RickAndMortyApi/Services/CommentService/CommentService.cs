using System.Linq;
using AutoMapper;
using RickAndMortyApi.Dtos.Comment;
using RickAndMortyApi.Models;
using System.Security.Claims;
using RickAndMortyApi.Filters;
using RickAndMortyApi.Services.TopicService;

namespace RickAndMortyApi.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITopicService _topicService;

        public CommentService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor, ITopicService topicService)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _topicService = topicService;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));


        public async Task<ServiceResponse<GetCommentDto>> GetCommentById(int id)
        {
            ServiceResponse<GetCommentDto> response = new ServiceResponse<GetCommentDto>();

            var comment = await _context.Comments.Include(c => c.User).Include(c => c.Topic).Where(c => c.Id == id).FirstOrDefaultAsync();

            if (comment == null)
            {
                response.Success = false;
                response.Message = "Comment not found";
                return response;
            }

            GetCommentDto commentDto = _mapper.Map<GetCommentDto>(comment);
            //commentDto.Topic = await _topicService.GetTopicById(comment.TopicId).Result.Data;

            response.Data = commentDto;

            return response;
        }

        //public async Task<ServiceResponse<List<GetCommentDto>>> GetCommentsByFilter(int amount, int page, CommentParameters parameters)
        //{
        //    ServiceResponse<List<GetCommentDto>> response = new ServiceResponse<List<GetCommentDto>>();

        //    amount = amount <= 0 ? 10 : amount;
        //    page = page <= 0 ? 1 : page;

        //    int requestedCommentsAmount = await _context.Comments.Where(c => (c.User.Id == parameters.UserId || parameters.UserId == null) &&
        //                                                                     (c.ParentId == parameters.ParentId || parameters.ParentId == null) &&
        //                                                                     (c.Type == parameters.Type || parameters.Type == null)).CountAsync();
        //    bool hasRemainder = requestedCommentsAmount % amount > 0;

        //    if (requestedCommentsAmount / amount + Convert.ToInt32(hasRemainder) < page)
        //    {
        //        response.Success = false;
        //        response.Message = "Comment(s) not found.";
        //        return response;
        //    }

        //    List<GetCommentDto> comments = await _context.Comments.Where(c => (c.User.Id == parameters.UserId || parameters.UserId == null) &&
        //                                                                      (c.ParentId == parameters.ParentId || parameters.ParentId == null) &&
        //                                                                      (c.Type == parameters.Type || parameters.Type == null) &&
        //                                                                      (c.RelatedElementId == parameters.RelatedElementId || parameters.RelatedElementId == null)).
        //                                                           OrderBy(c => c.CreateDate).Skip(amount * (page - 1)).
        //                                                           Take(amount).Select(c => _mapper.Map<GetCommentDto>(c)).ToListAsync();

        //    if (comments == null)
        //    {
        //        response.Success = false;
        //        response.Message = "Comment(s) not found.";
        //        return response;
        //    }

        //    response.Data = comments;

        //    return response;
        //}

        public async Task<ServiceResponse<GetCommentDto>> AddComment(AddCommentDto newComment)
        {
            ServiceResponse<GetCommentDto> response = new ServiceResponse<GetCommentDto>();

            Comment comment = _mapper.Map<Comment>(newComment);
            comment.User = await _context.UserProfiles.FirstOrDefaultAsync(u => u.UserId == GetUserId());
            comment.CreateDate = DateTime.Now;
            comment.UpdateDate = comment.CreateDate;

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            response.Data = GetCommentById(comment.Id).Result.Data;

            return response;

            //Comment comment = _mapper.Map<Comment>(newComment);
            //comment.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            //comment.CreateDate = DateTime.Now;
            //comment.UpdateDate = comment.CreateDate;

            //_context.Comments.Add(comment);
            //await _context.SaveChangesAsync();

            //response.Data = await _context.Comments.Where(c => c.Id == comment.Id).Select(c => _mapper.Map<GetCommentDto>(c)).FirstOrDefaultAsync();

            //return response;
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

            if (comment.User == null || comment.User.UserId != GetUserId())
            {
                response.Success = false;
                response.Message = "Access denied.";
                return response;
            }

            comment.Text = updatedComment.Text;
            comment.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();

            response.Data = GetCommentById(comment.Id).Result.Data;

            return response;
        }

    }
}
