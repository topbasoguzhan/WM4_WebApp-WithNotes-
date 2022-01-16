using AutoMapper;
using ItServiceApp.Models.Identity;
using ItServiceApp.ViewModels;

namespace ItServiceApp.MapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<ApplicationUser, UserProfileViewModel>().ReverseMap();
            //CreateMap<UserProfileViewModel, ApplicationUser>(); //reversmap kullandığımız için bunu yazmamıza gerek yok.
        }

    }
}

