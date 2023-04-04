using DotNetCoreAngularApp.DataAccess.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCoreAngularApp.DataAccess.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<ProvinceEntity>
    {
        public void Configure(EntityTypeBuilder<ProvinceEntity> builder)
        {
            builder.ToTable("Province");
            builder.HasKey(p => p.ProvinceId);

            builder.Property(e => e.ProvinceId)
                .HasColumnName("ProvinceId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CountryCode)
                .HasColumnName("CountryCode")
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(200);

            builder.HasOne(p => p.Country)
                .WithMany(m => m.Provinces)
                .HasForeignKey(k => k.CountryCode)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new ProvinceEntity { ProvinceId = 1, CountryCode = "C1", Name = "Province 1.1" },
                new ProvinceEntity { ProvinceId = 2, CountryCode = "C1", Name = "Province 1.2" },
                new ProvinceEntity { ProvinceId = 3, CountryCode = "C2", Name = "Province 2.1" },
                new ProvinceEntity { ProvinceId = 4, CountryCode = "C2", Name = "Province 2.2" }
            );
        }
    }
}
