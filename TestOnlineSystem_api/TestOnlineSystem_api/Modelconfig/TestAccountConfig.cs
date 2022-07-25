using Microsoft.EntityFrameworkCore;
using Mini_project_API.Models;

namespace Mini_project_API.Modelconfig
{
    public static class TestAccountConfig
    {
        public static void ConfigTestAccount(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestAccount>()
                .Property(ta => ta.Id).UseIdentityColumn(1, 1);
        }
    }
}
