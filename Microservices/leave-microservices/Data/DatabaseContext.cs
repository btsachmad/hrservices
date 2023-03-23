using HRServicesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRServicesAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Leave> Leaves { get; set; }
        public DbSet<View_LeaveDateSeries> View_LeaveDateSeries { get; set; }
    }
}
