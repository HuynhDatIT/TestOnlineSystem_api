using AutoMapper;
using Microsoft.AspNetCore.Http;
using Mini_project_API.Enum;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IService;
using Mini_project_API.Models;
using Mini_project_API.ViewModel.Request;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Linq;
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
        }

        public async Task CreateTestAsync(CreateTest createtest)
        {
            var test = _mapper.Map<Test>(createtest);

            await _unitOfWork.TestRepository.AddAsync(test);

            await _unitOfWork.SaveChangesAsync();

            var testQuestions = createtest.ListQuestionId.Select(x => new TestQuestion
                                {
                                    QuestionId = x,
                                    TestId = test.Id
                                }).ToList();

            await _unitOfWork.TestQuestionRepository.AddRangeAsync(testQuestions);

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
            var test = await _unitOfWork.TestRepository.GetTestForReportAsync(testid);

            if (test == null)
                return null;

            var report = _mapper.Map<GetReportTest>(test);

            report.AccountReports = _mapper.Map<IList<GetAccountReport>>
                                    (test.TestAccounts.Select(x => new GetAccountReport
                                    {
                                        Id = x.Id,
                                        FullName = x.Account.Fullname,
                                        Scores = x.Scores,
                                        Rank = GetRank(x.Scores)
                                    }));

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
        private static string GetRank(int scores)
        {
            if (scores < 5)
                return Rank.Yeu.ToString();
            else if (scores < 7)
                return Rank.TrungBinh.ToString();
            else if (scores < 8)
                return Rank.Kha.ToString();
            else
                return Rank.Gioi.ToString();
        }
    }
}
