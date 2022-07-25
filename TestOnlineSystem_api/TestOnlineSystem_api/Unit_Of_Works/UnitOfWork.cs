using Microsoft.EntityFrameworkCore;
using Mini_project_API.Data;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IRepository;
using Mini_project_API.Models;
using Mini_project_API.Repository;
using System.Threading.Tasks;

namespace Mini_project_API.Unit_Of_Works
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IElearningDbContext _db;
        private IQuestionRepository questionRepository;
        private IAnswerRepository answerRepository;
        private ITestRepository testRepository;
        private ITestQuestionRepository testQuestionRepository;
        private ITestAccountRepository testAccountRepository;
        private IAccountRepository accountRepository;
        public UnitOfWork(IElearningDbContext db)
        {
            _db = db;
            questionRepository = new QuestionRepository(_db);
           
            answerRepository = new AnswerRepository(_db);

            testQuestionRepository = new TestQuestionRepository(_db);

            testRepository = new TestRepository(_db);

            testAccountRepository = new TestAccountRepository(_db);
            accountRepository = new AccountRepository(_db);

        }

        public IQuestionRepository QuestionRepository
        {
            get { return questionRepository; }
        }

        public IAnswerRepository AnswerRepository
        {
            get { return answerRepository; }
        }

        public ITestRepository TestRepository
        {
            get { return testRepository; }
        }

        public ITestQuestionRepository TestQuestionRepository
        {
            get { return testQuestionRepository; }
        }

        public ITestAccountRepository TestAccountRepository
        {
            get { return testAccountRepository; }
        }

        public IAccountRepository AccountRepository
        {
            get { return accountRepository; }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        
    }
}
