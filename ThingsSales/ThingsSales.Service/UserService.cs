using AutoMapper;
using System.Text;
using ThingsSales.Data.Repositories.IRepository;
using ThingsSales.Model.Identity;
using ThingsSales.Service.IService;
using ThingsSales.Web.ViewModels;

namespace ThingsSales.Service
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
        public async Task<AuthUserViewModel> GetUserFullNameById(string userId)
        {
            var user = await _userRepository.GetById(userId);

            return _mapper.Map<AuthUserViewModel>(user);
        }
    }
}
