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

        public async Task<IList<GetAccountReport>> GetAccountsByTestIdAsync(int testId)
        {
            var accountReports = await _db.TestAccounts.Include(a => a.Account)
                                .Where(a => a.TestId == testId)
                                   .Select(a => new GetAccountReport
                                   {
                                       Id = a.Id,
                                       FullName = a.Account.Fullname,
                                       Scores = a.Scores,
                                       Rank = GetRank(a.Scores)
                                   })
                                   .ToListAsync();
            return accountReports;
        }

        private static string GetRank(int scores)
        {
            if (scores < 5)
                return Rank.Yeu.ToString();
            else if (scores < 7)
                return Rank.TrungBinh.ToString();
            else if (scores < 8)
                return Rank.Kha.ToString();
            else
                return Rank.Gioi.ToString();
        }

        public async Task<IList<TestAccount>> GetTestAccountByAccountIdAsync(int accountid)
        {
            var listTestAccount = await _db.TestAccounts
                                    .Where(ta => ta.AccountId == accountid).ToListAsync();
            return listTestAccount;
        }
    }
}
