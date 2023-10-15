using ThingsSales.Data.ContextData;
using ThingsSales.Data.Repositories.IRepository;
using ThingsSales.Model.Identity;

namespace ThingsSales.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetByIdAsync(string userId)
        {
            return await _context.ApplicationUsers.FindAsync(userId);
        }
    }
}
