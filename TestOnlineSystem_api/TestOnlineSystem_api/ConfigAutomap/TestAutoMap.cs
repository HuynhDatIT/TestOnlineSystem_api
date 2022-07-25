using AutoMapper;
using Mini_project_API.Models;
using Mini_project_API.ViewModel.Request;
using Mini_project_API.ViewModel.Response;

namespace DatHT8_Mini_project_API.ConfigAutomap
{
    public class TestAutoMap : Profile
    {
        public TestAutoMap()
        {

            CreateMap<CreateTest, Test>();

            CreateMap<Test, GetTest>().ReverseMap();
            
            CreateMap<GetReportTest, Test>().ReverseMap();

        }
    }
}
