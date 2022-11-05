using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class BeheerderEntityTypeConfiguration : IEntityTypeConfiguration<Beheerder>
    {
        public void Configure(EntityTypeBuilder<Beheerder> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.HogentEmail);
            builder.Property(p => p.Role).IsRequired();

        }
    }
}