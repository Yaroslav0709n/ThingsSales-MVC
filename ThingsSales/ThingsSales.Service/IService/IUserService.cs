using ThingsSales.Service.ViewModels;

namespace ThingsSales.Service.IService
{
    public interface IUserService
    {
        Task<AuthUserViewModel> GetUserById(string userId);
    }
}
