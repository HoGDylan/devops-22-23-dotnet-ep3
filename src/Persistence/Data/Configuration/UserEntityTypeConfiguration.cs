/*using Domain.Gebruiker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<Gebruiker>
    {
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.HogentEmail);
        }
    }
}*/