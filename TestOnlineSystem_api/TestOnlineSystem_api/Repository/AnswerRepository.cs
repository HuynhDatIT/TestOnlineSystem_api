using Microsoft.EntityFrameworkCore;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IRepository;
using Mini_project_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_project_API.Repository
{
    public class AnswerRepository : GenericRepositoryCRUD<Answer>, IAnswerRepository
    {
        public AnswerRepository(IElearningDbContext db) : base(db)
        {
        }

        public async Task<IList<Answer>> GetAnswersByQuestionIdAsync(int id)
        {
            var listAnswer = await _dbSet
                                .Where(x => x.QuestionId == id).ToListAsync();
            return listAnswer;
        }
    }
}
