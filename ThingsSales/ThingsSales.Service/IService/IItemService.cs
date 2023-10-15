using Microsoft.AspNetCore.Http;
using ThingsSales.Model;
using ThingsSales.Service.ViewModels;

namespace ThingsSales.Service.IService
{
    public interface IAdvertismentService
    {
        Task<ItemViewModel> InsertItem(ItemViewModel item, List<IFormFile> photos, string userId);
        Task<IEnumerable<ItemViewModel>> GetAllUserItemsById(string userId);
        Task<IEnumerable<ItemViewModel>> GetAllItems();
        Task<ItemViewModel> GetItemById(int itemId);
    }
}
