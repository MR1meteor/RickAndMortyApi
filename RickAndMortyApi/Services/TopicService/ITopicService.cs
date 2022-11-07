using Rick;
using RickAndMortyApi.Dtos.Topic;
using RickAndMortyApi.Models;

namespace RickAndMortyApi.Services.TopicService
{
    public interface ITopicService
    {
        public Task<ServiceResponse<GetTopicDto<object>>> GetTopicById(int id);
        public Task<ServiceResponse<GetTopicDto<object>>> AddTopic(AddTopicDto newTopic);
    }
}
