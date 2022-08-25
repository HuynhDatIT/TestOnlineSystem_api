using Microsoft.EntityFrameworkCore;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IRepository;
using Mini_project_API.Models;
using Mini_project_API.ViewModel.Response;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_project_API.Repository
{
    public class TestRepository : GenericRepositoryCRUD<Test>, ITestRepository
    {
        public TestRepository(IElearningDbContext db) : base(db)
        {
        }

        public async Task<string> GetTitleTestByIdAsync(int id)
        {
            var title = await _dbSet
                            .Where(t => t.Id == id)
                                .Select(t => t.Title).FirstOrDefaultAsync();
            return title;
        }
        public async Task<Test> GetTestForReportAsync(int testId)
        {
            return await _dbSet.Where(x => x.Id == testId)
                               .Include(x => x.TestAccounts)
                               .ThenInclude(x => x.Account).FirstOrDefaultAsync();
        }
        public async Task<Test> GetTestAsync(int testId)
        {
            return await _dbSet.Where(x => x.Id == testId)
                               .Include(x => x.TestQuestions)
                               .ThenInclude(x => x.Question)
                               .ThenInclude(x => x.Answers)
                               .FirstOrDefaultAsync();
        }
    }
}
