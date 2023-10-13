using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using ThingsSales.Data.Repositories.IRepository;
using ThingsSales.Data.ValidationExtensions;
using ThingsSales.Model;
using ThingsSales.Service.IService;
using ThingsSales.Service.ViewModels;

namespace ThingsSales.Service.Service
{
    public class AdvertisementService : IAdvertismentService
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepository _itemRepository;

        public AdvertisementService(IMapper mapper, 
                           IAdvertisementRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<AdvertisementViewModel>> GetAllItems(string userId)
        {
            var items = await _itemRepository.GetItemsAsync(userId);

            items.ThrowIfNull(nameof(items));

            return _mapper.Map<IEnumerable<AdvertisementViewModel>>(items);
        }

        public async Task<AdvertisementViewModel> GetItemById(int itemId)
        {
            var item = await _itemRepository.GetItemByIdAsync(itemId);

            item.ThrowIfNull(nameof(item));

            return _mapper.Map<AdvertisementViewModel>(item); ;
        }

        public async Task<AdvertisementViewModel> InsertItem(AdvertisementViewModel item, List<IFormFile> photos, string userId)
        {
            var newItem = _mapper.Map<Item>(item);

            newItem.ApplicationUserId = userId;
            newItem.Time = DateTime.Now;
            newItem.Date = DateTime.Today;

            var createdItem = await _itemRepository.AddItemAsync(newItem, photos);
            return _mapper.Map<AdvertisementViewModel>(createdItem);
        }
    }
}
