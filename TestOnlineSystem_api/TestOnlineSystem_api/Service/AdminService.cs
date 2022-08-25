using AutoMapper;
using Mini_project_API.Enum;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IService;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_project_API.Service
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ActiveAccountAsync(int id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);

            if (account == null)
            {
                return false;
            }

            account.IsActive = true;

            _unitOfWork.AccountRepository.Update(account);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> BlockAccountAsync(int id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);

            if (account == null)
                return false;

            account.IsBlock = true;

            _unitOfWork.AccountRepository.Update(account);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<IList<GetAccount>> GetAccountsAsync()
        {
            var accounts = await _unitOfWork.AccountRepository.GetAllWithRoleNameAsync();

            var lisiGetAccount = _mapper.Map<List<GetAccount>>(accounts);

            return lisiGetAccount;
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
