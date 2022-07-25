﻿using Microsoft.EntityFrameworkCore;
using Mini_project_API.Helper;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IRepository;
using Mini_project_API.Models;
using Mini_project_API.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_project_API.Repository
{
    public class AccountRepository : GenericRepositoryCRUD<Account>, IAccountRepository
    {
        public AccountRepository(IElearningDbContext db) : base(db)
        {
        }

        public Account Authentication(LoginViewModel loginViewModel)
        {

            var result = _db.Accounts.Include(a => a.Role)
                                        .Where(a => a.Username == loginViewModel.Username
                                            && a.Password == loginViewModel.Password.HashMD5())
                                                .FirstOrDefault();
            return result;
        }


        public async Task<string> GetAccountFullNameByIdAsync(int id)
        {
            var fullname = await _db.Accounts
                            .Where(a => a.Id == id)
                                .Select(a => a.Fullname).FirstOrDefaultAsync();
            return fullname;
        }

        public async Task<IList<Account>> GetAllRoleNameAsync()
        {
            var accounts = await _db.Accounts.Include(a => a.Role).ToListAsync();
            return accounts;
        }
    }
}
