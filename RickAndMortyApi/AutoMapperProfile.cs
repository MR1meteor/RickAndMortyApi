using AutoMapper;
using RickAndMortyApi.Dtos.Comment;
using RickAndMortyApi.Models;

namespace RickAndMortyApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Comment, GetCommentDto>();
            CreateMap<AddCommentDto, Comment>();
        }
    }
}
