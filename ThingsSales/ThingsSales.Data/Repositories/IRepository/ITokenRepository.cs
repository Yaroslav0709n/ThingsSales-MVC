using ThingsSales.Model.Identity;

namespace ThingsSales.Data.Repositories.IRepository
{
    public interface ITokenRepository
    {
        string CreateToken(ApplicationUser user);
    }
}
