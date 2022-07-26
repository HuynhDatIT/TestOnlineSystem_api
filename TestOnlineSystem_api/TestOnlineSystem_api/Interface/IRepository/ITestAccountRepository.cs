﻿using Mini_project_API.Models;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mini_project_API.Interface.IRepository
{
    public interface ITestAccountRepository : IGenericRepositoryCRUD<TestAccount>
    {
        Task<IList<TestAccount>> GetTestAccountByAccountIdAsync(int accountid);
    }
}
