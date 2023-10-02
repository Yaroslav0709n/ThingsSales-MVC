using AutoMapper;
using ThingsSales.Model.Identity;
using ThingsSales.Web.ViewModels;

namespace ThingsSales.Service.Mappings
{
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<AuthUserViewModel, ApplicationUser>();
            CreateMap<ApplicationUser, AuthUserViewModel>();


        }
    }
}
