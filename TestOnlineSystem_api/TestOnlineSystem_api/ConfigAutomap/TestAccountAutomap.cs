using AutoMapper;
using Mini_project_API.Models;
using Mini_project_API.ViewModel.Request;
using Mini_project_API.ViewModel.Response;

namespace DatHT8_Mini_project_API.ConfigAutomap
{
    public class TestAccountAutomap : Profile
    {
        public TestAccountAutomap()
        {
            CreateMap<CreateTestAccount, TestAccount>().ReverseMap();

            CreateMap<GetTestAccount, TestAccount>().ReverseMap();
        }
    }
}
