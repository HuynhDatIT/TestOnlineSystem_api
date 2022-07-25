using Mini_project_API.ViewModel;
using Mini_project_API.ViewModel.Request;

namespace Mini_project_API.Interface.IService
{
    public interface ILoginService
    {
        Tokens Authentica(LoginViewModel loginViewModel);

      
    }
}
