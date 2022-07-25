using AutoMapper;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IService;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
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

            if(account == null)
            {
                return false;
            }

            account.IsActive = true;

            _unitOfWork.AccountRepository.Update(account);

            _unitOfWork.SaveChanges();
            
            return true;
        }

        public async Task<bool> BlockAccountAsync(int id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);

            if(account == null)
                return false;

            account.IsBlock = true;

            _unitOfWork.AccountRepository.Update(account);

            _unitOfWork.SaveChanges();

            return true;
        }

        public async Task<IList<GetAccount>> GetAccountsAsync()
        {
            var accounts = await _unitOfWork.AccountRepository.GetAllRoleNameAsync();
            
            var lisiGetAccount = _mapper.Map<List<GetAccount>>(accounts);
            
            return lisiGetAccount;
        }

        public async Task<GetReportTest> GetReportTestAsync(int testid)
        {
            var test = await _unitOfWork.TestRepository.GetByIdAsync(testid);
            if(test == null)
                return null;
            var report = _mapper.Map<GetReportTest>(test);

            var listAccountReport = await _unitOfWork.TestAccountRepository
                                        .GetAccountsByTestIdAsync(testid);

             report.AccountReports = listAccountReport;

            return report;
        }
    }
}
