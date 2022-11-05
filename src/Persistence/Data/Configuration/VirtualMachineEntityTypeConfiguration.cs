using Domain.VirtualMachines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class VirtualMachineEntityTypeConfiguration : IEntityTypeConfiguration<VirtualMachine>
    {
        public void Configure(EntityTypeBuilder<VirtualMachine> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Project).IsRequired();
            builder.Property(p => p.OperatingSystem).IsRequired();
            builder.Property(p => p.Mode).IsRequired();
            builder.Property(p => p.Hardware.Memory).IsRequired();
            builder.Property(p => p.Hardware.Storage).IsRequired();
            builder.Property(p => p.Hardware.Amount_vCPU).IsRequired();
            builder.Property(p => p._contract);
            builder.Property(p => p.Connection).IsRequired();
            builder.Property(p => p.BackUp.Type).IsRequired();
            builder.Property(p => p.BackUp.LastBackup).IsRequired();
        }
    }
}