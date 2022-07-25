using Mini_project_API.ViewModel.Request;
using System.Threading.Tasks;

namespace Mini_project_API.Interface.IService
{
    public interface IRegisterService
    {
        Task RegisterAsync(CreateAccount createAccount);

    }
}
