using Domain.VirtualMachines;
using Domain.VirtualMachines.VirtualMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class VirtualMachineEntityTypeConfiguration : IEntityTypeConfiguration<VirtualMachine>
    {
        public void Configure(EntityTypeBuilder<VirtualMachine> builder)
        {
            /*builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.OperatingSystem).IsRequired();
            builder.Property(p => p.Mode).IsRequired();
            builder.Property(p => p.Hardware.Memory).IsRequired();
            builder.Property(p => p.Hardware.Storage).IsRequired();
            builder.Property(p => p.Hardware.Amount_vCPU).IsRequired();
            builder.Property(p => p.Contract);
            builder.Property(p => p.Connection).IsRequired();
            builder.Property(p => p.BackUp.Type).IsRequired();
            builder.Property(p => p.BackUp.LastBackup).IsRequired();
            builder.Property(p => p.Statistics).IsRequired();*/

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.OperatingSystem).IsRequired();
            builder.Property(p => p.Mode).IsRequired();
            builder.HasOne(p => p.Hardware).WithMany().HasForeignKey(u => u.Id).IsRequired();
            builder.HasOne(p => p.Contract).WithMany().HasForeignKey(u => u.Id);
            builder.HasOne(p => p.Connection).WithMany().HasForeignKey(u => u.Id).IsRequired();
            builder.HasOne(p => p.BackUp).WithMany().HasForeignKey(u => u.Id).IsRequired();
            builder.HasOne(p => p.Statistics).WithMany().HasForeignKey(u => u.Id).IsRequired();
        }
    }
}