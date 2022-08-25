using Mini_project_API.Models;
using Mini_project_API.ViewModel.Response;
using System.Threading.Tasks;

namespace Mini_project_API.Interface.IRepository
{
    public interface ITestRepository : IGenericRepositoryCRUD<Test>
    {
        Task<string> GetTitleTestByIdAsync(int id);
        Task<Test> GetTestForReportAsync(int testId);
    }
}
