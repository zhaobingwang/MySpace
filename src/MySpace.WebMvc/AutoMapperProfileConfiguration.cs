using AutoMapper;
using MySpace.Infrastructure.Identity;
using MySpace.WebMvc.Areas.Console.Models.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySpace.WebMvc
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("default.profile")
        {

        }
        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<ApplicationUser, UserListViewModel>();
            CreateMap<ApplicationUserPageResult, UserPagesViewModel>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.CurrentPageUsers));

            //CreateMap<ApplicationUser, UserListViewModel>();
            //CreateMap<ApplicationUserPageResult, UserPagesViewModel>();
        }
    }
}
