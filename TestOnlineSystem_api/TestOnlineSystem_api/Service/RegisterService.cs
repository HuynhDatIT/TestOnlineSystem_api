using AutoMapper;
using Mini_project_API.Helper;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IService;
using Mini_project_API.Models;
using Mini_project_API.ViewModel.Request;
using System.Threading.Tasks;

namespace Mini_project_API.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task RegisterAsync(CreateAccount createAccount)
        {
            createAccount.Password = createAccount.Password.HashMD5();
           
            var account = _mapper.Map<Account>(createAccount);
            
            await _unitOfWork.AccountRepository.AddAsync(account);
            
            _unitOfWork.SaveChanges();
        }
    }
}
