using Microsoft.EntityFrameworkCore;
using Mini_project_API.Enum;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IRepository;
using Mini_project_API.Models;
using Mini_project_API.ViewModel.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_project_API.Repository
{
    public class TestAccountRepository : GenericRepositoryCRUD<TestAccount>, ITestAccountRepository
    {
        public TestAccountRepository(IElearningDbContext db) : base(db)
        {
        }

        public async Task<IList<TestAccount>> GetTestAccountByAccountIdAsync(int accountid)
        {
            var listTestAccount = await _dbSet
                                    .Where(ta => ta.AccountId == accountid).ToListAsync();
            return listTestAccount;
        }
    }
}
