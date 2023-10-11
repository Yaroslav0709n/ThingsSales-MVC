using AutoMapper;
using ThingsSales.Model;
using ThingsSales.Service.ViewModels;

namespace ThingsSales.Service.Mappings
{
    public class ItemMapper:Profile
    {
        public ItemMapper()
        {
            CreateMap<ItemViewModel, Item>();
            CreateMap<Item, ItemViewModel>();
        }
    }
}
