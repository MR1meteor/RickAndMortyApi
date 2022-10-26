using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMortyApi.Dtos.Comment;
using RickAndMortyApi.Models;
using RickAndMortyApi.Services.CommentService;

namespace RickAndMortyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCommentDto>>> AddComment(AddCommentDto newComment)
        {
            ServiceResponse<GetCommentDto> response = await _commentService.AddComment(newComment);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
