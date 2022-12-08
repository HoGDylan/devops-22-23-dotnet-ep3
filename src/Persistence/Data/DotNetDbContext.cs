using Domain.VirtualMachines.VirtualMachine;
using Domain.Server;
using Domain.VirtualMachines.Contract;
using Microsoft.EntityFrameworkCore;
using Domain;
using Persistence.Data.Configuration;
using Domain.Common;
using Domain.Statistics;
using Domain.VirtualMachines.BackUp;

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

        public DbSet<Gebruiker> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VMConnection>();
            modelBuilder.Entity<Statistic>();
            modelBuilder.Entity<Backup>();
            modelBuilder.Entity<ContactDetails>();
            modelBuilder.Entity<Hardware>();

            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new ContactDetailsEntityTypeConfiguration());
            //modelBuilder.Entity<ContactDetails>().Property(f => f.Id).ValueGeneratedOnAdd();
            //modelBuilder.ApplyConfiguration(new HardwareEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new KlantEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VMContractEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FysiekeServerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VirtualMachineEntityTypeConfiguration());

        }
    }
}
