using AutoMapper;
using Mini_project_API.Models;
using Mini_project_API.ViewModel.Request;
using Mini_project_API.ViewModel.Response;

namespace DatHT8_Mini_project_API.ConfigAutomap
{
    public class AnswerAutomap : Profile
    {
        public AnswerAutomap()
        {
            CreateMap<PostAnswer, Answer>().ReverseMap();
            CreateMap<GetAnswer, Answer>().ReverseMap();

        }
    }
}
