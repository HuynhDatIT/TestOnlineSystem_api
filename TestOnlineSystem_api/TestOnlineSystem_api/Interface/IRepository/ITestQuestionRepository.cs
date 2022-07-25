using Mini_project_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_project_API.Interface.IRepository
{
    public interface ITestQuestionRepository : IGenericRepositoryCRUD<TestQuestion>
    {
        Task AddListAsync(IList<TestQuestion> testquestions);

        Task<IList<int>> GetQuestionIdByTestIdAsync (int testId);
    }
}
