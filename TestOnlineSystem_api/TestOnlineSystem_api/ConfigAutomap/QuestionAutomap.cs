using AutoMapper;
using Mini_project_API.Models;
using Mini_project_API.ViewModel.Request;
using Mini_project_API.ViewModel.Response;

namespace DatHT8_Mini_project_API.ConfigAutomap
{
    public class QuestionAutomap : Profile
    {
        public QuestionAutomap()
        {
            CreateMap<Question, GetQuestion>().ReverseMap();

            CreateMap<CreateQuestionAnswer, Question>();
        }
    }
}
