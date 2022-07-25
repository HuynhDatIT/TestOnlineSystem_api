using Microsoft.EntityFrameworkCore;
using Mini_project_API.Models;

namespace Mini_project_API.Modelconfig
{
    public static class AnswerConfig
    {
        public static void ConfigAnswer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .Property(a => a.Id).UseIdentityColumn(1, 1);
        }
    }
}
