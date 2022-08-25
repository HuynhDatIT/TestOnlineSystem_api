using Mini_project_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_project_API.Interface.IRepository
{
    public interface IAnswerRepository : IGenericRepositoryCRUD<Answer>
    {
        Task<IList<Answer>> GetAnswersByQuestionIdAsync(int id);
    }
}
