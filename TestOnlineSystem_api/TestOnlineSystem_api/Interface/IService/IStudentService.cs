using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_project_API.Interface.IService
{
    public interface IStudentService
    {
        Task<GetTest> GetTestAsync (int id);
        Task<IList<GetTestAccount>> GetTestAccountByAccountIdAsync (int id);
       
    }
}
