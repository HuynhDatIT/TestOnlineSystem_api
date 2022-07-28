using AutoMapper;
using Microsoft.AspNetCore.Http;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IService;
using Mini_project_API.Models;
using Mini_project_API.ViewModel.Request;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_project_API.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateQuestionAnswerAsync(CreateQuestionAnswer questionAnswer)
        {
            var question = _mapper.Map<Question>(questionAnswer);
            
            await _unitOfWork.QuestionRepository.AddAsync(question);
            
            await _unitOfWork.SaveChangesAsync();

            var answers = _mapper.Map<IList<Answer>>(questionAnswer.PostAnswers);

            var questionID = await _unitOfWork.QuestionRepository.GetLastQuestionIdAsync();
           
            foreach (var item in answers)
            {
                item.QuestionId = questionID;
            }
            
            await _unitOfWork.AnswerRepository.AddListAsync(answers);
            
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CreateTestAsync(CreateTest createtest)
        {
            var test = _mapper.Map<Test>(createtest);
            
            await _unitOfWork.TestRepository.AddAsync(test);

            await _unitOfWork.SaveChangesAsync();
            
            var testId = await _unitOfWork.TestRepository.GetLastTestIdAsync();
            
            var questionsId = createtest.ListQuestionId;

            var listtestquestion = new List<TestQuestion>();
            foreach (var item in questionsId)
            {
                var testquestion = new TestQuestion
                {
                    TestId = testId,
                    QuestionId = item
                };
                listtestquestion.Add(testquestion);
            }
            
            await _unitOfWork.TestQuestionRepository.AddListAsync(listtestquestion);
            
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CreateTestAccountAsync(CreateTestAccount createtestaccount)
        {
            var test = _mapper.Map<TestAccount>(createtestaccount);
           
            await _unitOfWork.TestAccountRepository.AddAsync(test);
            
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetReportTest> GetReportTestAsync(int testid)
        {
            var test = await _unitOfWork.TestRepository.GetByIdAsync(testid);
           
            if (test == null)
                return null;
            
            var report = _mapper.Map<GetReportTest>(test);

            var listAccountReport = await _unitOfWork.TestAccountRepository
                                        .GetAccountsByTestIdAsync(testid);

            report.AccountReports = listAccountReport;

            return report;
        }

        public async Task<IEnumerable<GetTestAccount>> GetTestAccountsAsync()
        {
            var testAccountList = await _unitOfWork.TestAccountRepository.GetAllAsync();
          
            var getTestAccountList = _mapper.Map<IEnumerable<GetTestAccount>>(testAccountList);

            foreach (var item in getTestAccountList)
            {
                item.Fullname = await _unitOfWork.AccountRepository
                                .GetAccountFullNameByIdAsync(item.AccountId);
                
                item.TestTitle = await _unitOfWork.TestRepository.GetTitleTestByIdAsync(item.TestId);
            }
            return getTestAccountList;
        }

    }
}
