using Domain.VirtualMachines;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class DotNetDbContext : DbContext
    {
        public DotNetDbContext(DbContextOptions<DotNetDbContext> options)
            : base(options)
        {
        }

        public DbSet<VirtualMachine> VirtualMachines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
