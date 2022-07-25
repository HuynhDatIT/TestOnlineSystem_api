using Mini_project_API.Models;
using Mini_project_API.ViewModel.Request;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_project_API.Interface.IService
{
    public interface ITeacherService
    {
        Task CreateQuestionAnswerAsync(CreateQuestionAnswer postquestion);
        Task CreateTestAsync(CreateTest createtest);
        Task CreateTestAccountAsync(CreateTestAccount createtestaccount);
        Task<IEnumerable<GetTestAccount>> GetTestAccountsAsync();
        Task<GetReportTest> GetReportTestAsync(int testid);
    }
}
