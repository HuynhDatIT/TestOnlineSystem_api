using Mini_project_API.Models;
using Mini_project_API.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_project_API.Interface.IRepository
{
    public interface IAccountRepository : IGenericRepositoryCRUD<Account>
    {
        Task<string> GetAccountFullNameByIdAsync(int id);
        Account Authentication(LoginViewModel loginViewModel);

        Task<IList<Account>> GetAllWithRoleNameAsync();

       
    }
}
