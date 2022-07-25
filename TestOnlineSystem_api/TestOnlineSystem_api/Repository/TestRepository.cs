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

        public async Task<int> GetLastTestIdAsync()
        {
           var testLastId = await _db.Tests
                                    .Select(t => t.Id)
                                        .LastOrDefaultAsync();
            return testLastId;
        }

        public async Task<string> GetTitleTestByIdAsync(int id)
        {
            var title = await _db.Tests
                            .Where(t => t.Id == id)
                                .Select(t => t.Title).FirstOrDefaultAsync();
            return title;
        }
    }
}
