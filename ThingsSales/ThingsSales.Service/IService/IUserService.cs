using ThingsSales.Model.Identity;
using ThingsSales.Web.ViewModels;

namespace ThingsSales.Service.IService
{
    public interface IUserService
    {
        Task<AuthUserViewModel> GetUserFullNameById(string userId);
    }
}
