using Microsoft.AspNetCore.Http;
using ThingsSales.Model;

namespace ThingsSales.Data.Repositories.IRepository
{
    public interface IItemRepository
    {
        Task<Item> AddItemAsync(Item item, List<IFormFile> photos);
        Task<IEnumerable<Item>> GetUserItemsAsync(string userId);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemByIdAsync(int itemId);
    }
}
