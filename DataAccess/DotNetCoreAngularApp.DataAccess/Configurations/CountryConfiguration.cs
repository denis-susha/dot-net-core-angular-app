using DotNetCoreAngularApp.DataAccess.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCoreAngularApp.DataAccess.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {

            builder.ToTable("Country");
            builder.HasKey(p => p.CountryCode);

            builder.Property(p => p.CountryCode)
                .IsRequired()
                .HasColumnName("CountryCode")
                .HasMaxLength(2);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(200);

            builder.HasData(
                new CountryEntity { CountryCode = "C1", Name = "Country 1" },
                new CountryEntity { CountryCode = "C2", Name = "Country 2" }
            );
        }
    }
}
