using Microsoft.EntityFrameworkCore;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IRepository;
using Mini_project_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_project_API.Repository
{
    public class TestQuestionRepository : GenericRepositoryCRUD<TestQuestion>, ITestQuestionRepository
    {
        public TestQuestionRepository(IElearningDbContext db) : base(db)
        {
        }

        public async Task AddListAsync(IList<TestQuestion> testquestion)
        {
           await _db.TestQuestions.AddRangeAsync(testquestion);
        }

        public async Task<IList<int>> GetQuestionIdByTestIdAsync(int testId)
        {
            var listQuestionId = await _db.TestQuestions
                                    .Where(x => x.TestId == testId)
                                    .Select(x => x.QuestionId)
                                    .ToListAsync();
            return listQuestionId;
        }
    }
}
