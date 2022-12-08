using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class HardwareEntityTypeConfiguration : IEntityTypeConfiguration<Hardware>
    {
        public void Configure(EntityTypeBuilder<Hardware> builder)
        {
            builder.Property(p => p.Memory).IsRequired();
            builder.Property(p => p.Storage).IsRequired();
            builder.Property(p => p.Amount_vCPU).IsRequired();

        }

    }
}