using AutoMapper;
using RickAndMortyApi.Dtos.Comment;
using RickAndMortyApi.Dtos.List;
using RickAndMortyApi.Dtos.ListObject;
using RickAndMortyApi.Dtos.Profile;
using RickAndMortyApi.Dtos.Topic;
using RickAndMortyApi.Models;

namespace RickAndMortyApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Comment, GetCommentDto>();
            CreateMap<AddCommentDto, Comment>();
            CreateMap<UserProfile, GetProfileDto>();
            CreateMap<Topic, GetTopicDto<object>>();
            CreateMap<AddTopicDto, Topic>();
            CreateMap<ListObject, GetListObjectDto<object>>();
            CreateMap<AddListObjectDto, ListObject>();
            CreateMap<ListModel, GetListDto>();
        }
    }
}
