using Microsoft.AspNetCore.Http;
using ThingsSales.Model;
using ThingsSales.Service.ViewModels;

namespace ThingsSales.Service.IService
{
    public interface IItemService
    {
        Task<ItemViewModel> InsertItem(ItemViewModel item, List<IFormFile> photos, string userId);
        Task<IEnumerable<ItemViewModel>> GetAllItems(string userId);
        Task<ItemViewModel> GetItemById(int itemId);
    }
}
