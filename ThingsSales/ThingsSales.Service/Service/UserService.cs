using AutoMapper;
using ThingsSales.Data.Repositories.IRepository;
using ThingsSales.Data.ValidationExtensions;
using ThingsSales.Service.IService;
using ThingsSales.Service.ViewModels;

namespace ThingsSales.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<AuthUserViewModel> GetUserById(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            user.ThrowIfNull(nameof(user));

            return _mapper.Map<AuthUserViewModel>(user);
        }
    }
}
