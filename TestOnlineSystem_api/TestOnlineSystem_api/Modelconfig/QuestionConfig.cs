using Microsoft.EntityFrameworkCore;
using Mini_project_API.Models;

namespace Mini_project_API.Modelconfig
{
    public static class QuestionConfig
    {
        public static void ConfigQuestion(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .Property(q => q.Id).UseIdentityColumn(1, 1);

            modelBuilder.Entity<Question>()
                .Property(q => q.IsOnlyAnswer)
                .HasDefaultValue(true);
        }
    }
}
