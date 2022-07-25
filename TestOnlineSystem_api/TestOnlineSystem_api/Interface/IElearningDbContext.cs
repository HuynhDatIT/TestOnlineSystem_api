using Microsoft.EntityFrameworkCore;
using Mini_project_API.Models;
using System;

namespace Mini_project_API.Interface
{
    public interface IElearningDbContext : IDisposable
    {

        DbSet<Account> Accounts { get; set; }
        DbSet<Answer> Answers { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<TestAccount> TestAccounts { get; set; }
        DbSet<TestQuestion> TestQuestions { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
