using Domain.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class FysiekeServerEntityTypeConfiguration : IEntityTypeConfiguration<FysiekeServer>
    {
        public void Configure(EntityTypeBuilder<FysiekeServer> builder)
        {
            /*builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.ServerAddress).IsRequired();
            builder.Property(p => p.HardWare.Memory).IsRequired();
            builder.Property(p => p.HardWare.Storage).IsRequired();
            builder.Property(p => p.HardWare.Amount_vCPU).IsRequired();
            builder.Property(p => p.HardWareAvailable.Memory).IsRequired();
            builder.Property(p => p.HardWareAvailable.Storage).IsRequired();
            builder.Property(p => p.HardWareAvailable.Amount_vCPU).IsRequired();*/

            builder.Property(p => p.Name).IsRequired();
            builder.HasOne(p => p.HardWare).WithMany().HasForeignKey(u => u.Id).IsRequired();
            builder.Property(p => p.ServerAddress).IsRequired();

            //builder.Property(p => p.HardWareAvailable);
        }
    }
}