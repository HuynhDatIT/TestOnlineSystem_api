using Microsoft.EntityFrameworkCore;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IRepository;
using Mini_project_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_project_API.Repository
{
    public class QuestionRepository : GenericRepositoryCRUD<Question>, IQuestionRepository
    {
        public QuestionRepository(IElearningDbContext db): base(db)
        {
        }
    }
}
