using Microsoft.EntityFrameworkCore;
using Mini_project_API.Helper;
using Mini_project_API.Models;

namespace Mini_project_API.Modelconfig
{
    public static class SeedData
    {

        public static void SeedAllDataNew(this ModelBuilder modelbuild)
        {
            modelbuild.Entity<Role>().HasData(
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "teacher" },
                new Role { Id = 3, Name = "student" }
                );
            modelbuild.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    Username = "admin",
                    Password = "123456".HashMD5(),
                    Fullname = "Huynh Tan Dat",
                    IsActive = true,
                    RoleId = 1,
                },
                  new Account
                  {
                      Id = 2,
                      Username = "teacherA",
                      Password = "123456".HashMD5(),
                      Fullname = "Giao vien A",
                      IsActive = true,
                      RoleId = 2,
                  },
                 new Account
                 {
                     Id = 3,
                     Username = "studentA",
                     Password = "123456".HashMD5(),
                     Fullname = "Hoc sinh A",
                     IsActive = true,
                     RoleId = 3,
                 },
                   new Account
                   {
                       Id = 4,
                       Username = "studentB",
                       Password = "123456".HashMD5(),
                       Fullname = "Hoc sinh B",
                       IsActive = true,
                       RoleId = 3,
                   },
                   new Account
                   {
                       Id = 5,
                       Username = "studentC",
                       Password = "123456".HashMD5(),
                       Fullname = "Hoc sinh C",
                       RoleId = 3,
                   }
                );
            modelbuild.Entity<Test>().HasData(
                new Test
                {
                    Id = 1,
                    Title = "Final C#",
                    Minute = 100,
                },
                new Test
                {
                    Id = 2,
                    Title = "Final Sql",
                    Minute = 100,
                },
                new Test
                {
                    Id = 3,
                    Title = "Final Web Api",
                    Minute = 100,
                }
                );
            modelbuild.Entity<TestAccount>().HasData(
                new TestAccount
                {
                    Id = 1,
                    AccountId = 3,
                    TestId = 1,
                    IsComplete = true,
                    Scores = 10

                },
                new TestAccount
                {
                    Id = 2,
                    AccountId = 3,
                    TestId = 2,
                    IsComplete = true,
                    Scores = 9
                },
                new TestAccount
                {
                    Id = 3,
                    AccountId = 4,
                    TestId = 1,
                    IsComplete = true,
                    Scores = 5
                },
                new TestAccount
                {
                    Id = 4,
                    AccountId = 4,
                    TestId = 3,
                    IsComplete = false,
                },
                new TestAccount
                {
                    Id = 5,
                    AccountId = 4,
                    TestId = 1,
                    IsComplete = true,
                    Scores = 8
                },
                new TestAccount
                {
                    Id = 6,
                    AccountId = 5,
                    TestId = 2,
                    IsComplete = true,
                    Scores = 2
                }
                );
            modelbuild.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    ContentQuestion = "1 + 1",
                    PathImage = "",
                },
                new Question
                {
                    Id = 2,
                    ContentQuestion = "1 + 2",
                    PathImage = "",
                },
                new Question
                {
                    Id = 3,
                    ContentQuestion = "1 + 3",
                    PathImage = "",
                },
                new Question
                {
                    Id = 4,
                    ContentQuestion = "1 + 4",
                    PathImage = "",
                },
                new Question
                {
                    Id = 5,
                    ContentQuestion = "em + anh",
                    IsOnlyAnswer = false,
                    PathImage = "",
                }
                );
            modelbuild.Entity<Answer>().HasData(
                //question 1
                new Answer
                {
                    Id = 1,
                    QuestionId = 1,
                    ContentAnswer = "1",
                    PathImage = "",
                    Istrue = false
                },
                new Answer
                {
                    Id = 2,
                    QuestionId = 1,
                    ContentAnswer = "2",
                    PathImage = "",
                    Istrue = true
                },
                new Answer
                {
                    Id = 3,
                    QuestionId = 1,
                    ContentAnswer = "3",
                    PathImage = "",
                    Istrue = false
                },
                new Answer
                {
                    Id = 4,
                    QuestionId = 1,
                    ContentAnswer = "4",
                    PathImage = "",
                    Istrue = false
                },
                //question 2
                new Answer
                {
                    Id = 5,
                    QuestionId = 2,
                    ContentAnswer = "1",
                    PathImage = "",
                    Istrue = false
                },
                new Answer
                {
                    Id = 6,
                    QuestionId = 2,
                    ContentAnswer = "2",
                    PathImage = "",
                    Istrue = false
                },
                new Answer
                {
                    Id = 7,
                    QuestionId = 2,
                    ContentAnswer = "3",
                    PathImage = "",
                    Istrue = true
                },
                new Answer
                {
                    Id = 8,
                    QuestionId = 2,
                    ContentAnswer = "4",
                    PathImage = "",
                    Istrue = false
                },
                //question 3
                new Answer
                {
                    Id = 9,
                    QuestionId = 3,
                    ContentAnswer = "1",
                    PathImage = "",
                    Istrue = false
                },
                new Answer
                {
                    Id = 10,
                    QuestionId = 3,
                    ContentAnswer = "2",
                    PathImage = "",
                    Istrue = false
                },
                new Answer
                {
                    Id = 11,
                    QuestionId = 3,
                    ContentAnswer = "3",
                    PathImage = "",
                    Istrue = false
                },
                new Answer
                {
                    Id = 12,
                    QuestionId = 3,
                    ContentAnswer = "4",
                    PathImage = "",
                    Istrue = true
                },
                //question 4
                new Answer
                {
                    Id = 13,
                    QuestionId = 4,
                    ContentAnswer = "1",
                    PathImage = "",
                    Istrue = false
                },
                new Answer
                {
                    Id = 14,
                    QuestionId = 4,
                    ContentAnswer = "2",
                    PathImage = "",
                    Istrue = false
                },
                new Answer
                {
                    Id = 15,
                    QuestionId = 4,
                    ContentAnswer = "3",
                    PathImage = "",
                    Istrue = false
                },
                new Answer
                {
                    Id = 16,
                    QuestionId = 4,
                    ContentAnswer = "5",
                    PathImage = "",
                    Istrue = true
                },
                // question 5
                new Answer
                {
                    Id = 17,
                    QuestionId = 5,
                    ContentAnswer = "1",
                    PathImage = "",
                    Istrue = true
                },
                new Answer
                {
                    Id = 18,
                    QuestionId = 5,
                    ContentAnswer = "0",
                    PathImage = "",
                    Istrue = true
                }
                );
            modelbuild.Entity<TestQuestion>().HasData(
                //test 1
                new TestQuestion
                {
                    Id = 1,
                    TestId = 1,
                    QuestionId = 1
                },
                new TestQuestion
                {
                    Id = 2,
                    TestId = 1,
                    QuestionId = 2
                },
                new TestQuestion
                {
                    Id = 3,
                    TestId = 1,
                    QuestionId = 3
                },
                new TestQuestion
                {
                    Id = 4,
                    TestId = 1,
                    QuestionId = 4
                },
                new TestQuestion
                {
                    Id = 5,
                    TestId = 1,
                    QuestionId = 5
                },
                //test 2
                new TestQuestion
                {
                    Id = 6,
                    TestId = 2,
                    QuestionId = 1
                },
                new TestQuestion
                {
                    Id = 7,
                    TestId = 2,
                    QuestionId = 5
                },
                new TestQuestion
                {
                    Id = 8,
                    TestId = 2,
                    QuestionId = 3
                },
                //test 3
                new TestQuestion
                {
                    Id = 9,
                    TestId = 3,
                    QuestionId = 2
                },
                new TestQuestion
                {
                    Id = 10,
                    TestId = 3,
                    QuestionId = 5
                },
                new TestQuestion
                {
                    Id = 11,
                    TestId = 3,
                    QuestionId = 3
                }
                );
        }
    }
}
