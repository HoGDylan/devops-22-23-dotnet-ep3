using Domain.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class FysiekeServerEntityTypeConfiguration : IEntityTypeConfiguration<FysiekeServer>
    {
        public void Configure(EntityTypeBuilder<FysiekeServer> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.ServerAddress).IsRequired();
            builder.Property(p => p.HardWare.Memory).IsRequired();
            builder.Property(p => p.HardWare.Storage).IsRequired();
            builder.Property(p => p.HardWare.Amount_vCPU).IsRequired();
            builder.Property(p => p.MemoryAvailable).IsRequired();
            builder.Property(p => p.StorageAvailable).IsRequired();
            builder.Property(p => p.VCPUsAvailable).IsRequired();
        }
    }
}