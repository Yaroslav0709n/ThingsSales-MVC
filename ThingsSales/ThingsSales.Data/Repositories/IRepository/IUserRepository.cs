using ThingsSales.Model.Identity;

namespace ThingsSales.Data.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetById(string userId);
    }
}
