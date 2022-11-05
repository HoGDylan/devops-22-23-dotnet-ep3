using Domain.VirtualMachines;
using Domain.Server;
using Domain.Contract;
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

        public DbSet<FysiekeServer> fysiekeServers { get; set; }

        public DbSet<VMContract> VMContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
