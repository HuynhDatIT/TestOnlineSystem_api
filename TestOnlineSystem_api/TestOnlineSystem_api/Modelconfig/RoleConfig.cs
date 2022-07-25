using Microsoft.EntityFrameworkCore;
using Mini_project_API.Models;

namespace Mini_project_API.Modelconfig
{
    public static class RoleConfig
    {
        public static void ConfigRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Property(r => r.Id).UseIdentityColumn(1, 1);
        }
    }
}
