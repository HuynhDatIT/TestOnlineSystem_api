using Microsoft.EntityFrameworkCore;
using Mini_project_API.Models;
using System;

namespace Mini_project_API.Modelconfig
{
    public static class TestConfig
    {
        public static void ConfigTest(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
               .Property(t => t.Id).UseIdentityColumn(1, 1);

            modelBuilder.Entity<Test>()
                .Property(t => t.TestDay)
                .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Test>()
                .Property(t => t.MaxScores)
                .HasDefaultValue(10);
        }
    }
}
