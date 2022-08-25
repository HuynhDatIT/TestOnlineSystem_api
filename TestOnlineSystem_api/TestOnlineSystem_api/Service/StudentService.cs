using AutoMapper;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IService;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_project_API.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetTest> GetTestAsync(int id)
        {
            var test = await _unitOfWork.TestRepository.GetTestForReportAsync(id);
            
            if(test == null)
                return null;

            var gettest = _mapper.Map<GetTest>(test);
           
            var listQuestionId = await _unitOfWork
                                    .TestQuestionRepository.GetQuestionIdByTestIdAsync(id);
            
            var listQuestion = new List<GetQuestion>();
            
            var listAnswer = new List<GetAnswer>();
            
            foreach (var iditem in listQuestionId)
            {
                var question = await _unitOfWork.QuestionRepository.GetByIdAsync(iditem);
                
                var getquestion = _mapper.Map<GetQuestion>(question);
                
                var listanswer = await _unitOfWork.AnswerRepository
                                    .GetAnswersByQuestionIdAsync(iditem);
                
                var getanswers = _mapper.Map <List<GetAnswer>>(listanswer);
                
                getquestion.Answers = getanswers;
                
                listQuestion.Add(getquestion);
            }
          
            gettest.Questions = listQuestion;
     
            return gettest;
        }

        public async Task<IList<GetTestAccount>> GetTestAccountByAccountIdAsync(int id)
        {
            var testaccount = await _unitOfWork.TestAccountRepository
                                        .GetTestAccountByAccountIdAsync(id);
            if (testaccount.Count == 0)
                return null;
           
            var getTestAccountList = _mapper.Map<IList<GetTestAccount>>(testaccount);
           
            foreach (var item in getTestAccountList)
            {
                item.Fullname = await _unitOfWork.AccountRepository
                                    .GetAccountFullNameByIdAsync(item.AccountId);
                item.TestTitle = await _unitOfWork.TestRepository
                                    .GetTitleTestByIdAsync(item.TestId);
            }
            return getTestAccountList;
        }
    }
}
