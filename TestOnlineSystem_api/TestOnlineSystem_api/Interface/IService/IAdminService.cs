using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_project_API.Interface.IService
{
    public interface IAdminService
    {
        Task<bool> ActiveAccountAsync(int id);

        Task<bool> BlockAccountAsync(int id);

        Task<IList<GetAccount>> GetAccountsAsync();

        Task<GetReportTest> GetReportTestAsync(int testid);
    }
}
