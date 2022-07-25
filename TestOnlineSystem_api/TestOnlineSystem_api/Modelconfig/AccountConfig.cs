using Microsoft.EntityFrameworkCore;
using Mini_project_API.Models;

namespace Mini_project_API.Modelconfig
{
    public static class AccountConfig
    {
        public static void ConfigAccount(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Account>()
                .Property(a => a.IsBlock)
                .HasDefaultValue(false);
            modelBuilder.Entity<Account>()
                .Property(a => a.IsActive)
                .HasDefaultValue(false);
        }
    }
}
