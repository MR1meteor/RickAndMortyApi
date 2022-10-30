﻿using AutoMapper;
using RickAndMortyApi.Dtos.Comment;
using RickAndMortyApi.Dtos.Profile;
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
        }
    }
}
