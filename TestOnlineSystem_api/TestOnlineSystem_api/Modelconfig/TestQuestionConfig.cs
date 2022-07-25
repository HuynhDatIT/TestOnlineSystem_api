using Microsoft.EntityFrameworkCore;
using Mini_project_API.Models;

namespace Mini_project_API.Modelconfig
{
    public static class TestQuestionConfig
    {
        public static void ConfigTestQuestion(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestQuestion>()
                .Property(tq => tq.Id).UseIdentityColumn(1, 1);
        }
    }
}
