using AutoMapper;
using Mini_project_API.Models;
using Mini_project_API.ViewModel.Request;
using Mini_project_API.ViewModel.Response;

namespace DatHT8_Mini_project_API.ConfigAutomap
{
    public class AccountAutomap : Profile
    {
        public AccountAutomap()
        {

            CreateMap<CreateAccount, Account>().ReverseMap();

            CreateMap<GetAccount, Account>().ReverseMap()
                .ForMember(ga => ga.RoleName, a => a.MapFrom(a => a.Role.Name));
        }
    }
}
