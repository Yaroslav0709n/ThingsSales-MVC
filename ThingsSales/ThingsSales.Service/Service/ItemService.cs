using AutoMapper;
using Microsoft.AspNetCore.Http;
using ThingsSales.Data.Repositories.IRepository;
using ThingsSales.Data.ValidationExtensions;
using ThingsSales.Model;
using ThingsSales.Service.IService;
using ThingsSales.Service.ViewModels;

namespace ThingsSales.Service.Service
{
    public class ItemService : IAdvertismentService
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public ItemService(IMapper mapper, 
                           IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemViewModel>> GetAllItems()
        {
            var items = await _itemRepository.GetItemsAsync();

            items.ThrowIfNull(nameof(items));

            return _mapper.Map<IEnumerable<ItemViewModel>>(items);
        }

        public async Task<IEnumerable<ItemViewModel>> GetAllUserItemsById(string userId)
        {
            var items = await _itemRepository.GetUserItemsAsync(userId);

            items.ThrowIfNull(nameof(items));

            return _mapper.Map<IEnumerable<ItemViewModel>>(items);
        }

        public async Task<ItemViewModel> GetItemById(int itemId)
        {
            var item = await _itemRepository.GetItemByIdAsync(itemId);

            item.ThrowIfNull(nameof(item));

            return _mapper.Map<ItemViewModel>(item); ;
        }

        public async Task<ItemViewModel> InsertItem(ItemViewModel item, List<IFormFile> photos, string userId)
        {
            var newItem = _mapper.Map<Item>(item);

            newItem.ApplicationUserId = userId;
            newItem.Time = DateTime.Now;
            newItem.Date = DateTime.Today;

            var createdItem = await _itemRepository.AddItemAsync(newItem, photos);
            return _mapper.Map<ItemViewModel>(createdItem);
        }
    }
}
