using AutoMapper;
using RickAndMortyApi.Dtos.Profile;
using RickAndMortyApi.Models;
using System.Security.Claims;

namespace RickAndMortyApi.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<GetProfileDto>> GetProfileById(int id)
        {
            ServiceResponse<GetProfileDto> response = new ServiceResponse<GetProfileDto>();

            var profile = await _context.UserProfiles.Where(p => p.UserId == id).Select(p => _mapper.Map<GetProfileDto>(p)).FirstOrDefaultAsync();

            if (profile == null)
            {
                response.Success = false;
                response.Message = "Profile not found.";
                return response;
            }

            response.Data = profile;

            return response;
        }

        public async Task<ServiceResponse<GetProfileDto>> UpdateProfile(UpdateProfileDto updatedProfile)
        {
            ServiceResponse<GetProfileDto> response = new ServiceResponse<GetProfileDto>();

            //var comment = await _context.Comments.Include(c => c.User).FirstOrDefaultAsync(c => c.Id.Equals(updatedComment.Id));
            var profile = await _context.UserProfiles.Include(p => p.User).FirstOrDefaultAsync(p => p.Id.Equals(updatedProfile.Id));

            if (profile == null)
            {
                response.Success = false;
                response.Message = "Profile not found.";
                return response;
            }

            if (profile.User == null || profile.UserId != GetUserId())
            {
                response.Success = false;
                response.Message = "Access denied.";
                return response;
            }

            profile.Nickname = updatedProfile.Nickname;
            profile.Name = updatedProfile.Name;
            profile.Surname = updatedProfile.Surname;
            profile.Age = updatedProfile.Age;
            profile.Avatar = updatedProfile.Avatar;

            await _context.SaveChangesAsync();

            response.Data = await _context.UserProfiles.Where(p => p.Id == profile.Id).Select(p => _mapper.Map<GetProfileDto>(p)).FirstOrDefaultAsync();

            return response;
        }
    }
}
