using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class KlantEntityTypeConfiguration : IEntityTypeConfiguration<Klant>
    {
        public void Configure(EntityTypeBuilder<Klant> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.HogentEmail);
            builder.Property(p => p.ContactPersoon).IsRequired();
            builder.Property(p => p.ContactPersoonReserve).IsRequired();
            builder.Property(p => p.Project).IsRequired();

        }
    }
}