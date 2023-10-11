using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ThingsSales.Data.ContextData;
using ThingsSales.Data.Repositories.IRepository;
using ThingsSales.Model;

namespace ThingsSales.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string userId)
        {
            return await _context.Items.Where(x => x.ApplicationUserId == userId).Include(i => i.Photos).ToListAsync();
        }

        public async Task<Item> AddItemAsync(Item item, List<IFormFile> photos)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            foreach (var photo in photos)
            {
                using (var stream = new MemoryStream())
                {
                    photo.CopyTo(stream);
                    var itemPhoto = new Photo
                    {
                        ImageData = stream.ToArray(),
                        ItemId = item.Id,
                        Caption = "Caption",
                    };
                    _context.Photos.Add(itemPhoto);
                }
            }
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            return await _context.Items.FindAsync(itemId);
        }
    }
}
