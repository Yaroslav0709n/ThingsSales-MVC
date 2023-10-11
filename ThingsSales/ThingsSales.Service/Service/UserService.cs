using AutoMapper;
using ThingsSales.Data.Repositories.IRepository;
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
            var user = await _userRepository.GetById(userId);

            return _mapper.Map<AuthUserViewModel>(user);
        }
    }
}
