using Microsoft.AspNetCore.Http;
using ThingsSales.Model;
using ThingsSales.Service.ViewModels;

namespace ThingsSales.Service.IService
{
    public interface IAdvertismentService
    {
        Task<AdvertisementViewModel> InsertItem(AdvertisementViewModel item, List<IFormFile> photos, string userId);
        Task<IEnumerable<AdvertisementViewModel>> GetAllItems(string userId);
        Task<AdvertisementViewModel> GetItemById(int itemId);
    }
}
