using Microsoft.EntityFrameworkCore;
using Mini_project_API.Interface;
using Mini_project_API.Modelconfig;
using Mini_project_API.Models;
using System;

namespace Mini_project_API.Data
{
    public class ELearningDbContext : DbContext, IElearningDbContext
    {
        public ELearningDbContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Role> Roles { get ; set ; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestAccount> TestAccounts { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region 
            //Account
            modelBuilder.ConfigAccount();
            //Answer
            modelBuilder.ConfigAnswer();

            //Question
            modelBuilder.ConfigQuestion();
            //Role
            modelBuilder.ConfigRole();

            //Test
            modelBuilder.ConfigTest();
            //TestAccount
            modelBuilder.ConfigTestAccount();

            //TestQuestion
            modelBuilder.ConfigTestQuestion();

            #endregion
            modelBuilder.SeedAllDataNew();

        }
    }
}
