using Domain.Projecten;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Klant).IsRequired();
            builder.HasMany(p => p.VirtualMachines).WithOne().HasForeignKey(u => u.Id).IsRequired();


        }
    }
}