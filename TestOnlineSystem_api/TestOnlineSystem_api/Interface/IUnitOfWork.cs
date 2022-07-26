﻿using Mini_project_API.Interface.IRepository;
using Mini_project_API.Models;
using System.Threading.Tasks;

namespace Mini_project_API.Interface
{
    public interface IUnitOfWork
    {
        IQuestionRepository QuestionRepository { get; }
        IAnswerRepository AnswerRepository { get; }

        ITestRepository TestRepository { get; }
        ITestQuestionRepository TestQuestionRepository { get; }
        ITestAccountRepository TestAccountRepository { get; }
        IAccountRepository AccountRepository { get; }
        Task<int> SaveChangesAsync();
       
    }
}
